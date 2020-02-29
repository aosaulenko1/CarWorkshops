using CarWorkshops.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarWorkshops.Data
{
    public interface IDataContext
    {
        Task<TModel> AddAsync<TModel>(TModel model) where TModel : class, IModel;

        Task<TModel> UpdateAsync<TModel>(TModel model) where TModel : class, IModel;

        Task<TModel> RemoveAsync<TModel>(TModel model) where TModel : class, IModel;

        Task<IEnumerable<TModel>> FindByConditionAsync<TModel>(Expression<Func<TModel, bool>> expression) where TModel : class, IModel;
    }
}
