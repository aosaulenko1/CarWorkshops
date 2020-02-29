using CarWorkshops.WebApplication.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.WebApplication.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class UserDto : AddressDtoBase
    {
        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
