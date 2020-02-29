using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.WebApplication.Models.Abstracts
{
    public abstract class ModelDtoBase : IModelDto
    {
        protected ModelDtoBase()
        { }

        [Key]
        public Guid Id { get; set; }
    }
}
