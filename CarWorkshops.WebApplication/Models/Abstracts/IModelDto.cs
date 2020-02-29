using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public interface IModelDto
    {
        [Key]
        Guid Id { get; set; }
    }
}
