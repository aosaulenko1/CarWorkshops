using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Models.Mappers.Resolvers
{
    public class CarWorkshopCarTrademarksResolver : IValueResolver<CarWorkshopDto, CarWorkshopModel, IEnumerable<CarTrademarkModel>>, ICarWorkshopCarTrademarksResolver
    {
        private readonly ICarTrademarksRepository _carTrademarksRepository;

        public CarWorkshopCarTrademarksResolver(ICarTrademarksRepository carTrademarksRepository)
        {
            _carTrademarksRepository = carTrademarksRepository;
        }

        public IEnumerable<CarTrademarkModel> Resolve(CarWorkshopDto source, CarWorkshopModel destination, IEnumerable<CarTrademarkModel> destMember, ResolutionContext context)
        {
            return Resolve(source);
        }

        public IEnumerable<CarTrademarkModel> Resolve(CarWorkshopDto source)
        {
            return Sync.Run(() => ResolveAsync(source));
        }

        private async Task<IEnumerable<CarTrademarkModel>> ResolveAsync(CarWorkshopDto source)
        {
            var trademarks = source.GetTrademarks();
            var carTrademarkModels = new List<CarTrademarkModel>();
            foreach (var trademark in trademarks)
            {
                var carTrademarkModel = _carTrademarksRepository.Resolve(o => o.Trademark.ToLower() == trademark.ToLower());
                if (carTrademarkModel == null)
                {
                    carTrademarkModel = new CarTrademarkModel { Trademark = trademark };
                    await _carTrademarksRepository.AddAsync(carTrademarkModel);
                }
                carTrademarkModels.Add(carTrademarkModel);
            }
            return carTrademarkModels;
        }
    }
}