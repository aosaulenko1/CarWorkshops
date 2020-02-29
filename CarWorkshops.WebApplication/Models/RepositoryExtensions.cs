using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Models
{
    public static class RepositoryExtensions
    {
        public static UserModel Resolve(this IModelsRepository<UserModel> source, Expression<Func<UserModel, bool>> expression)
        {
            return Resolve((IUsersRepository)source, expression);
        }

        public static UserModel Resolve(this IUsersRepository source, Expression<Func<UserModel, bool>> expression)
        {
            return Sync.Run(() => ResolveAsync(source, expression));
        }

        private static async Task<UserModel> ResolveAsync(IUsersRepository usersRepository, Expression<Func<UserModel, bool>> expression)
        {
            var models = await usersRepository.FindByConditionAsync(expression);
            return models.FirstOrDefault();
        }

        public static CarWorkshopModel Resolve(this IModelsRepository<CarWorkshopModel> source, Expression<Func<CarWorkshopModel, bool>> expression)
        {
            return Resolve((ICarWorkshopsRepository)source, expression);
        }

        public static CarWorkshopModel Resolve(this ICarWorkshopsRepository source, Expression<Func<CarWorkshopModel, bool>> expression)
        {
            return Sync.Run(() => ResolveAsync(source, expression));
        }

        private static async Task<CarWorkshopModel> ResolveAsync(ICarWorkshopsRepository carWorkshopsRepository, Expression<Func<CarWorkshopModel, bool>> expression)
        {
            var models = await carWorkshopsRepository.FindByConditionAsync(expression);
            return models.FirstOrDefault();
        }

        public static CarTrademarkModel Resolve(this ICarTrademarksRepository source, Expression<Func<CarTrademarkModel, bool>> expression)
        {
            return Sync.Run(() => ResolveAsync(source, expression));
        }

        private static async Task<CarTrademarkModel> ResolveAsync(ICarTrademarksRepository carTrademarksRepository, Expression<Func<CarTrademarkModel, bool>> expression)
        {
            var models = await carTrademarksRepository.FindByConditionAsync(expression);
            return models.FirstOrDefault();
        }
    }
}
