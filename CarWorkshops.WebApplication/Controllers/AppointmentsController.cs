using AutoMapper;
using CarWorkshops.Data.Exceptions;
using CarWorkshops.Data.Models;
using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Controllers
{
    public class AppointmentsController : ModelsControllerBase<AppointmentDto, AppointmentModel, AppointmentsController>
    {
        public AppointmentsController(IRepository repository, IMapper mapper, ILogger<AppointmentsController> logger) :
            base(repository.Appointments, mapper, logger)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]AppointmentUpdateDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await ModelsRepository.FindByIdAsync(appointmentDto.Id);
            if (model == null)
            {
                throw new ModelNotFoundException(nameof(AppointmentModel.Id), appointmentDto.Id, typeof(AppointmentModel));
            }
            model.WhenOccured = appointmentDto.WhenOccured;
            if (!TryValidateModel(model))
            {
                return BadRequest(ModelState);
            }
            await ModelsRepository.UpdateAsync(model);
            return Ok();
        }
    }
}
