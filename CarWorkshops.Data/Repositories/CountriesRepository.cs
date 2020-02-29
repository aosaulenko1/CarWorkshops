using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using DataAccess.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class CountriesRepository : ModelsRepositoryBase<CountryModel>, ICountriesRepository
    {
        public CountriesRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
