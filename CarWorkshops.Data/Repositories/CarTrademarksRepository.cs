using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class CarTrademarksRepository : ModelsRepositoryBase<CarTrademarkModel>, ICarTrademarksRepository
    {
        public CarTrademarksRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
