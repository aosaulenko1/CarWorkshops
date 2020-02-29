using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
    public class AppointmentUserResolver : IValueResolver<AppointmentDto, AppointmentModel, UserModel>
    {
        private readonly IUsersRepository _usersRepository;

        public AppointmentUserResolver(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public UserModel Resolve(AppointmentDto source, AppointmentModel destination, UserModel destMember, ResolutionContext context)
        {
            return _usersRepository.Resolve(o => o.Username == source.Username);
        }
    }
}
