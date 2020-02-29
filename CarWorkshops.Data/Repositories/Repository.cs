using CarWorkshops.Data.Repositories.Abstracts;
using DataAccess.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class Repository : IRepository
    {
        public Repository(IAddressesRepository addressesRepository, IAppointmentsRepository appointmentsRepository,
            ICarTrademarksRepository carTrademarksRepository, ICarWorkshopsRepository carWorkshopsRepository,
            ICountriesRepository countriesRepository, IUsersRepository usersRepository)
        {
            Addresses = addressesRepository;
            Appointments = appointmentsRepository;
            CarTrademarks = carTrademarksRepository;
            CarWorkshops = carWorkshopsRepository;
            Countries = countriesRepository;
            Users = usersRepository;
        }

        public IAddressesRepository Addresses { get; }
        public IAppointmentsRepository Appointments { get; }
        public ICarTrademarksRepository CarTrademarks { get; }
        public ICarWorkshopsRepository CarWorkshops { get; }
        public ICountriesRepository Countries { get; }
        public IUsersRepository Users { get; }
    }
}
