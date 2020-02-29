using CarWorkshops.Data.Models;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public interface IAddressResolver
    {
        AddressModel Resolve(AddressDtoBase source);
    }
}