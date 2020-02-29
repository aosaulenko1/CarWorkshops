using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.Data.Repositories
{
    public class UsersRepository : ModelsRepositoryBase<UserModel>, IUsersRepository
    {
        public UsersRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
