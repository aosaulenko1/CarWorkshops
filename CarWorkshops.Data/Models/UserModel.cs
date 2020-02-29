using CarWorkshops.Data.Models.Abstracts;
using CarWorkshops.Data.Repositories.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWorkshops.Data.Models
{
    public class UserModel : ModelBase, IValidatableObject
    {
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public AddressModel Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Sync.Run(() => ValidateAsync(validationContext));
        }

        public async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            var usersRepository = (IUsersRepository)validationContext.GetService(typeof(IUsersRepository));
            var userModels =  await usersRepository.FindByConditionAsync(o => ModelsUtils.GetIsValueUnique(this, o, Username.ToLower(), o.Username.ToLower()));
            if (userModels.Any())
            {
                results.Add(new ValidationResult(ModelsMessages.GetModelFieldUniqueError(Username), new[] { nameof(Username) }));
            }

            userModels = await usersRepository.FindByConditionAsync(o => ModelsUtils.GetIsValueUnique(this, o, Email.ToLower(), o.Email.ToLower()));
            if (userModels.Any())
            {
                results.Add(new ValidationResult(ModelsMessages.GetModelFieldUniqueError(Email), new[] { nameof(Email) }));
            }

            return results;
        }
    }
}
