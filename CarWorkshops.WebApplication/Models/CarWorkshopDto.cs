using CarWorkshops.WebApplication.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarWorkshops.WebApplication.Models
{
    /// <summary>
    /// Car workshop
    /// </summary>
    public class CarWorkshopDto : AddressDtoBase
    {
        public const char CarTrademarksDelimiter = ',';

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Car trademarks specializes in (example BMW, VW)
        /// </summary>
        [Required]
        public string CarTrademarks { get; set; }

        public IEnumerable<string> GetTrademarks()
        {
            return CarTrademarks.Split(CarTrademarksDelimiter).Select(o => o.Trim()).Where(o => !string.IsNullOrWhiteSpace(o));
        }
    }
}
