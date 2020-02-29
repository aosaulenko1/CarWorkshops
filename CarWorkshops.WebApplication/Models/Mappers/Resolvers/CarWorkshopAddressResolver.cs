using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.WebApplication.Models.Abstracts;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
	public class CarWorkshopAddressResolver : IValueResolver<CarWorkshopDto, CarWorkshopModel, AddressModel>
	{
		private readonly IAddressResolver _addressResolver;

		public CarWorkshopAddressResolver(IAddressResolver addressResolver)
		{
			_addressResolver = addressResolver;
		}

		public AddressModel Resolve(CarWorkshopDto source, CarWorkshopModel destination, AddressModel destMember, ResolutionContext context)
		{
			return _addressResolver.Resolve(source);
		}
	}
}
