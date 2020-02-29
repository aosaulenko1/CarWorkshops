using CarWorkshops.Data.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models
{
    public class AddressModel : ModelBase
    {
        [Required]
        [MaxLength(250)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        public CountryModel Country { get; set; }
    }
}
