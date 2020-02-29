using DataAccess.Abstracts;

namespace CarWorkshops.Data.Repositories.Abstracts
{
    public interface IRepository
    {
        IAddressesRepository Addresses { get; }
        IAppointmentsRepository Appointments { get; }
        ICarTrademarksRepository CarTrademarks { get; }
        ICarWorkshopsRepository CarWorkshops { get; }
        ICountriesRepository Countries { get; }
        IUsersRepository Users { get; }
    }
}