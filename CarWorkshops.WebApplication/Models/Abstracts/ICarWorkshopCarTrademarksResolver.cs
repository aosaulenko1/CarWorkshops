using CarWorkshops.Data.Models;
using System.Collections.Generic;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public interface ICarWorkshopCarTrademarksResolver
    {
        IEnumerable<CarTrademarkModel> Resolve(CarWorkshopDto source);
    }
}
