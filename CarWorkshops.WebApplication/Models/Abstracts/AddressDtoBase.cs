using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public abstract class AddressDtoBase : ModelDtoBase
    {
        protected AddressDtoBase()
        { }

        [Required]
        [MaxLength(250)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(250)]
        public string Country { get; set; }
    }
}
