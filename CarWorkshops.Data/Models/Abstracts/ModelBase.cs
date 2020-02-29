using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshops.Data.Models.Abstracts
{
    public abstract class ModelBase : IModel
    {
        protected ModelBase()
        { }

        [Key]
        public Guid Id { get; set; }
    }
}
