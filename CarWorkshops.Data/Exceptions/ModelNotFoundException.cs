using CarWorkshops.Data.Models;
using System;

namespace CarWorkshops.Data.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(string fieldName, object value, Type modelType) : base(ModelsMessages.GetModelNotFoundMessage(fieldName, value, modelType))
        {
        }
    }
}
