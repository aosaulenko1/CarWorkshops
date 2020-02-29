using CarWorkshops.Data.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models
{
    public class CarTrademarkModel : ModelBase
    {
        [Required]
        [MaxLength(250)]
        public string Trademark { get; set; }
    }
}
