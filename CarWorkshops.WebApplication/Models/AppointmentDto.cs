using CarWorkshops.Data.Repositories.Abstracts;
using CarWorkshops.WebApplication.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarWorkshops.WebApplication.Models
{
    /// <summary>
    /// Appointment between a user and a car workshop
    /// </summary>
    public class AppointmentDto : AppointmentDtoBase, IValidatableObject
    {
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserCarTrademark { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            var repository = (IRepository)validationContext.GetService(typeof(IRepository));
            var userModel = repository.Users.Resolve(o => o.Username.ToLower() == Username.ToLower());
            if (userModel == null)
            {
                results.Add(new ValidationResult($"'{Username}' is not exist", new[] { nameof(Username) }));
            }

            var carTrademarkModel = repository.CarTrademarks.Resolve(o => o.Trademark.ToLower() == UserCarTrademark.ToLower());
            if (carTrademarkModel == null)
            {
                results.Add(new ValidationResult($"'{UserCarTrademark}' is not exist", new[] { nameof(UserCarTrademark) }));
            }

            var carWorkshopModel = repository.CarWorkshops.Resolve(o => o.CompanyName.ToLower() == CompanyName.ToLower());
            if (carWorkshopModel == null)
            {
                results.Add(new ValidationResult($"'{CompanyName}' is not exist", new[] { nameof(CompanyName) }));
            } else
            {
                if (carTrademarkModel != null && !carWorkshopModel.CarTrademarks.Any(c => c.Trademark.ToLower() == UserCarTrademark.ToLower()))
                {
                    results.Add(new ValidationResult($"'{CompanyName}' is not specialize in '{UserCarTrademark}'", new[] { nameof(CompanyName) }));
                }
            }

            return results;
        }
    }
}
