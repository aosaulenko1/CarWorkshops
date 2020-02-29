using CarWorkshops.Data.Models;
using System;

namespace CarWorkshops.Data.Exceptions
{
    public class UnknownModelException : Exception
    {
        public UnknownModelException(Type type) : base(ModelsMessages.GetUnknownModelMessage(type))
        {
        }
    }
}
