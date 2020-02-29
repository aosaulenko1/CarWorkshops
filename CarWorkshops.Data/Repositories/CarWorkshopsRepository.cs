using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class CarWorkshopsRepository : ModelsRepositoryBase<CarWorkshopModel>, ICarWorkshopsRepository
    {
        public CarWorkshopsRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
