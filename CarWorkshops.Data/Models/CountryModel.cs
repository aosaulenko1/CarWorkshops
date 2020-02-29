using CarWorkshops.Data.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models
{
    public class CountryModel : ModelBase
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
