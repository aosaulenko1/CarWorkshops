using CarWorkshops.Data.Models;
using CarWorkshops.Data.Models.Abstracts;
using System;

namespace CarWorkshops.Data.Exceptions
{
    public class DuplicateModelException : Exception
    {
        public DuplicateModelException(Guid id, Type type) : base(ModelsMessages.GetDuplicateModelMessage(nameof(IModel.Id), id, type))
        {
        }
    }
}
