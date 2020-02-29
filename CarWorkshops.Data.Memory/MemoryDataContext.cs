using CarWorkshops.Data;
using CarWorkshops.Data.Exceptions;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Models.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemoryDataContext : IDataContext
    {
        private Hashtable _addressModels = new Hashtable();
        private Hashtable _appointmentModels = new Hashtable();
        private Hashtable _carTrademarkModels = new Hashtable();
        private Hashtable _carWorkshopModels = new Hashtable();
        private Hashtable _countryModels = new Hashtable();
        private Hashtable _userModels = new Hashtable();

        public MemoryDataContext()
        {
            AddDemoData();
        }

        public async Task<TModel> AddAsync<TModel>(TModel model) where TModel : class, IModel
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
            }
            Hashtable hashtable = GetHashtable<TModel>();
            if (hashtable.ContainsKey(model.Id))
            {
                throw new DuplicateModelException(model.Id, typeof(TModel));
            }
            hashtable.Add(model.Id, model);
            return await Task.FromResult(model);
        }

        public async Task<TModel> UpdateAsync<TModel>(TModel model) where TModel : class, IModel
        {
            Hashtable hashtable = GetHashtable<TModel>();
            if (!hashtable.ContainsKey(model.Id))
            {
                throw new ModelNotFoundException("Id", model.Id, typeof(TModel));
            }
            hashtable[model.Id] = model;
            return await Task.FromResult(model);
        }

        public async Task<TModel> RemoveAsync<TModel>(TModel model) where TModel : class, IModel
        {
            Hashtable hashtable = GetHashtable<TModel>();
            if (!hashtable.ContainsKey(model.Id))
            {
                throw new ModelNotFoundException("Id", model.Id, typeof(TModel));
            }
            hashtable.Remove(model.Id);
            return await Task.FromResult(model);
        }

        public async Task<IEnumerable<TModel>> FindByConditionAsync<TModel>(Expression<Func<TModel, bool>> expression) where TModel : class, IModel
        {
            Hashtable hashtable = GetHashtable<TModel>();
            return await Task.FromResult(hashtable.Values.Cast<TModel>().AsQueryable().Where(expression));
        }

        private void AddDemoData()
        {
            Task.WaitAll(AddCarTrademarkModels().ToArray());
        }

        private IEnumerable<Task> AddCarTrademarkModels()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(AddAsync(new CarTrademarkModel { Trademark = "BMW" }));
            tasks.Add(AddAsync(new CarTrademarkModel { Trademark = "VW" }));
            return tasks;
        }

        private Hashtable GetHashtable<TModel>() where TModel : class, IModel
        {
            return GetHashtable(typeof(TModel));
        }

        private Hashtable GetHashtable(Type modelType)
        {
            if (modelType == typeof(AddressModel))
            {
                return _addressModels;
            }
            if (modelType == typeof(AppointmentModel))
            {
                return _appointmentModels;
            }
            if (modelType == typeof(CarTrademarkModel))
            {
                return _carTrademarkModels;
            }
            if (modelType == typeof(CarWorkshopModel))
            {
                return _carWorkshopModels;
            }
            if (modelType == typeof(CountryModel))
            {
                return _countryModels;
            }
            if (modelType == typeof(UserModel))
            {
                return _userModels;
            }
            return null;
        }
    }
}
