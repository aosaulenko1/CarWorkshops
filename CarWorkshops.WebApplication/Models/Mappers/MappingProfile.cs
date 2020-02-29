using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.WebApplication.Models.Mappers.Resolvers;
using System.Linq;

namespace CarWorkshops.WebApplication.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppointmentDto, AppointmentModel>()
                .ForMember(dst => dst.User, opt => opt.MapFrom<AppointmentUserResolver>())
                .ForMember(dst => dst.UserCarTrademark, opt => opt.MapFrom<AppointmentUserCarTrademarkModelResolver>())
                .ForMember(dst => dst.CarWorkshop, opt => opt.MapFrom<AppointmentCarWorkshopResolver>());
            CreateMap<CarWorkshopDto, CarWorkshopModel>()
                .ForMember(dst => dst.CarTrademarks, opt => opt.MapFrom<CarWorkshopCarTrademarksResolver>())
                .ForMember(dst => dst.Address, opt => opt.MapFrom<CarWorkshopAddressResolver>());
            CreateMap<UserDto, UserModel>()
                .ForMember(dst => dst.Address, opt => opt.MapFrom<UserAddressResolver>());
            CreateMap<CarWorkshopModel, CarWorkshopDto>()
                .AfterMap(CarWorkshopModel2CarWorkshopDtoAfterMap);
        }

        private void CarWorkshopModel2CarWorkshopDtoAfterMap(CarWorkshopModel src, CarWorkshopDto dst)
        {
            var address = src.Address;
            dst.City = address.City;
            dst.PostalCode = address.PostalCode;
            dst.Country = address.Country.Name;
            dst.CarTrademarks = string.Join(CarWorkshopDto.CarTrademarksDelimiter, src.CarTrademarks.Select(o => o.Trademark).OrderBy(o => o));
        }
    }
}
