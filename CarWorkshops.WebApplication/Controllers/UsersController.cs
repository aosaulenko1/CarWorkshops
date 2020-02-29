using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models;
using Microsoft.Extensions.Logging;

namespace CarWorkshops.WebApplication.Controllers
{
    public class UsersController : ModelsControllerBase<UserDto, UserModel, UsersController>
    {
        public UsersController(IRepository repository, IMapper mapper, ILogger<UsersController> logger) :
            base(repository.Users, mapper, logger)
        {
        }
    }
}
