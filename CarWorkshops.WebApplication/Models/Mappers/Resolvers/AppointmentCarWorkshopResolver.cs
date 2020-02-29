using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
    public class AppointmentCarWorkshopResolver : IValueResolver<AppointmentDto, AppointmentModel, CarWorkshopModel>
    {
        private readonly ICarWorkshopsRepository _carWorkshopsRepository;

        public AppointmentCarWorkshopResolver(ICarWorkshopsRepository carWorkshopsRepository)
        {
            _carWorkshopsRepository = carWorkshopsRepository;
        }

        public CarWorkshopModel Resolve(AppointmentDto source, AppointmentModel destination, CarWorkshopModel destMember, ResolutionContext context)
        {
            return _carWorkshopsRepository.Resolve(o => o.CompanyName == source.CompanyName);
        }
    }
}