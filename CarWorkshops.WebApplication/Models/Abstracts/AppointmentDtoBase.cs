using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public abstract class AppointmentDtoBase : ModelDtoBase
    {
        protected AppointmentDtoBase()
        { }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date and time")]
        public DateTime WhenOccured { get; set; }
    }
}
