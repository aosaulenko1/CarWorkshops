using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models.Abstracts
{
    public interface IModel
    {
        [Key]
        Guid Id { get; set; }
    }
}
