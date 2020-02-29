using AutoMapper;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CarWorkshops.WebApplication.Controllers
{
    public class CarWorkshopsController : ModelsControllerBase<CarWorkshopDto, CarWorkshopModel, CarWorkshopsController>
    {
        public CarWorkshopsController(IRepository repository, IMapper mapper, ILogger<CarWorkshopsController> logger) :
            base(repository.CarWorkshops, mapper, logger)
        {
        }

        [HttpGet("{city}")]
        [ResponseType(typeof(IEnumerable<CarWorkshopDto>))]
        public async Task<IActionResult> Search(string city)
        {
            var carWorkshopModels = await ModelsRepository.FindByConditionAsync(o => o.Address.City.ToLower() == city.ToLower());
            return Ok(Mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshopModels));
        }
    }
}
