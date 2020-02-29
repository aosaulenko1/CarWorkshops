using CarWorkshops.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarWorkshops.Data.Repositories.Abstracts
{
    public interface IModelsRepository<TModel> where TModel : class, IModel
    {
        Task<TModel> AddAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<TModel> DeleteAsync(Guid id);
        Task<TModel> FindByIdAsync(Guid id);
        Task<IEnumerable<TModel>> FindByConditionAsync(Expression<Func<TModel, bool>> expression);
    }
}