using CarWorkshops.Data.Exceptions;
using CarWorkshops.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarWorkshops.Data.Repositories.Abstracts
{
    public abstract class ModelsRepositoryBase<TModel> : IModelsRepository<TModel> where TModel : class, IModel
    {
        private readonly IDataContext _dataContext;

        protected ModelsRepositoryBase(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            if (model == null)
            {
                throw new UnknownModelException(typeof(TModel));
            }
            TModel existingModel = await FindByIdAsync(model.Id);
            if (existingModel != null)
            {
                throw new DuplicateModelException(model.Id, typeof(TModel));
            }
            return await _dataContext.AddAsync(model);
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            if (model == null)
            {
                throw new UnknownModelException(typeof(TModel));
            }
            TModel existingModel = await FindByIdAsync(model.Id);
            if (existingModel == null)
            {
                throw new ModelNotFoundException("Id", model.Id, typeof(TModel));
            }
            return await _dataContext.UpdateAsync(model);
        }

        public async Task<TModel> DeleteAsync(Guid id)
        {
            TModel model = await FindByIdAsync(id);
            if (model == null)
            {
                throw new ModelNotFoundException("Id", id, typeof(TModel));
            }
            return await _dataContext.RemoveAsync(model);
        }

        public async Task<IEnumerable<TModel>> FindByConditionAsync(Expression<Func<TModel, bool>> expression)
        {
            return await _dataContext.FindByConditionAsync(expression);
        }

        public async Task<TModel> FindByIdAsync(Guid id)
        {
            IEnumerable<TModel> models = await FindByConditionAsync(o => o.Id == id);
            return models.FirstOrDefault();
        }
    }
}
