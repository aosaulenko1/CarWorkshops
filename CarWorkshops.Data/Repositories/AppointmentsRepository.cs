using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class AppointmentsRepository : ModelsRepositoryBase<AppointmentModel>, IAppointmentsRepository
    {
        public AppointmentsRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
