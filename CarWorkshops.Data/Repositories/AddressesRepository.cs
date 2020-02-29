using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class AddressesRepository : ModelsRepositoryBase<AddressModel>, IAddressesRepository
    {
        public AddressesRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
