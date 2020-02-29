using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
    public class AppointmentUserCarTrademarkModelResolver : IValueResolver<AppointmentDto, AppointmentModel, CarTrademarkModel>
    {
        private readonly ICarTrademarksRepository _carTrademarksRepository;

        public AppointmentUserCarTrademarkModelResolver(ICarTrademarksRepository carTrademarksRepository)
        {
            _carTrademarksRepository = carTrademarksRepository;
        }

        public CarTrademarkModel Resolve(AppointmentDto source, AppointmentModel destination, CarTrademarkModel destMember, ResolutionContext context)
        {
            return _carTrademarksRepository.Resolve(o => o.Trademark == source.UserCarTrademark);
        }
    }
}