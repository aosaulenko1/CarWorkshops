using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.WebApplication.Models.Abstracts;

namespace CarWorkshops.WebApplication.Models.Mappers
{
	public class UserAddressResolver : IValueResolver<UserDto, UserModel, AddressModel>
	{
		private readonly IAddressResolver _addressResolver;

		public UserAddressResolver(IAddressResolver addressResolver)
		{
			_addressResolver = addressResolver;
		}

		public AddressModel Resolve(UserDto source, UserModel destination, AddressModel destMember, ResolutionContext context)
		{
			return _addressResolver.Resolve(source);
		}
	}
}
