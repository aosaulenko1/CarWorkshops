using CarWorkshops.Data.Models.Abstracts;
using CarWorkshops.Data.Repositories.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Data.Models
{
    public class CarWorkshopModel : ModelBase, IValidatableObject
    {
        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        public AddressModel Address { get; set; }

        public IEnumerable<CarTrademarkModel> CarTrademarks { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Sync.Run(() => ValidateAsync(validationContext));
        }

        public async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            var carWorkshopsRepository = (ICarWorkshopsRepository)validationContext.GetService(typeof(ICarWorkshopsRepository));
            var carWorkshopModels = await carWorkshopsRepository.FindByConditionAsync(o => ModelsUtils.GetIsValueUnique(this, o, CompanyName.ToLower(), o.CompanyName.ToLower()));
            if (carWorkshopModels.Any())
            {
                results.Add(new ValidationResult(ModelsMessages.GetModelFieldUniqueError(CompanyName), new[] { nameof(CompanyName) }));
            }

            return results;
        }
    }
}
