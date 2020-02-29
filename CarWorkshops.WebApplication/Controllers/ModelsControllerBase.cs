using AutoMapper;
using CarWorkshops.Data.Exceptions;
using CarWorkshops.Data.Models.Abstracts;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ModelsControllerBase<TModelDto, TModel, TController> : ControllerBase
        where TModelDto : class, IModelDto
        where TModel: class, IModel
        where TController: ControllerBase
    {
        protected readonly IModelsRepository<TModel> ModelsRepository;
        protected readonly IMapper Mapper;
        private readonly ILogger<TController> _logger;

        protected ModelsControllerBase(IModelsRepository<TModel> modelRepository,
            IMapper mapper, ILogger<TController> logger)
        {
            ModelsRepository = modelRepository;
            Mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]TModelDto modelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = Mapper.Map<TModel>(modelDto);
            if (!TryValidateModel(model))
            {
                return BadRequest(ModelState);
            }
            await ModelsRepository.AddAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await ModelsRepository.FindByIdAsync(id);
            if (model == null)
            {
                throw new ModelNotFoundException(nameof(IModel.Id), id, typeof(TModel));
            }
            await ModelsRepository.DeleteAsync(model.Id);
            return Ok();
        }
    }
}
