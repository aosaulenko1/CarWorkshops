using CarWorkshops.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models
{
    public class AppointmentModel : ModelBase, IValidatableObject
    {
        [Required]
        public UserModel User { get; set; }

        [Required]
        public CarTrademarkModel UserCarTrademark { get; set; }

        [Required]
        public CarWorkshopModel CarWorkshop { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime WhenOccured { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (WhenOccured < DateTime.Now)
            {
                results.Add(new ValidationResult($"{nameof(WhenOccured)} date and time must be greater than current time", new[] { nameof(WhenOccured) }));
            }

            return results;
        }
    }
}
