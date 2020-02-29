using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models.Abstracts;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
	public class AddressResolver : IAddressResolver
	{
		private readonly IRepository _repository;

		public AddressResolver(IRepository repository)
		{
			_repository = repository;
		}

		public AddressModel Resolve(AddressDtoBase source)
		{
			return Sync.Run(() => ResolveAsync(source));
		}

		private async Task<AddressModel> ResolveAsync(AddressDtoBase source)
		{
			var city = source.City;
			var postalCode = source.PostalCode;
			var countryName = source.Country;
			return await SaveAddressAsync(city, postalCode, countryName);
		}

		private async Task<AddressModel> SaveAddressAsync(string city, string postalCode, string countryName)
		{
			var addresses = await _repository.Addresses.FindByConditionAsync(o => o.City == city && o.PostalCode == postalCode && o.Country.Name == countryName);
			var address = addresses.FirstOrDefault();
			if (address == null)
			{
				var country = await SaveCountryAsync(countryName);
				address = await _repository.Addresses.AddAsync(new AddressModel { City = city, PostalCode = postalCode, Country = country });
			}
			return address;
		}

		private async Task<CountryModel> SaveCountryAsync(string name)
		{
			var countries = await _repository.Countries.FindByConditionAsync(o => o.Name == name);
			var country = countries.FirstOrDefault();
			if (country == null)
			{
				country = await _repository.Countries.AddAsync(new CountryModel { Name = name });
			}
			return country;
		}
	}
}
