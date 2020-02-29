using System;

namespace CarWorkshops.Data.Models
{
    public static class ModelsMessages
    {
        public static string GetDuplicateModelMessage(string fieldName, object value, Type modelType)
        {
            return GetModelMessage($"Duplicate {{0}} is found by {fieldName} '{value}'", modelType);
        }

        public static string GetModelFieldUniqueError(object value)
        {
            return $"'{value}' is not unique";
        }

        public static string GetModelNotFoundMessage(string fieldName, object value, Type modelType) 
        {
            return GetModelMessage($"{{0}} is not found by {fieldName} '{value}'", modelType);
        }

        public static string GetUnknownModelMessage(Type modelType)
        {
            return GetModelMessage($"{{0}} is unknown or null", modelType);
        }

        private static string GetModelMessage(string message, Type modelType)
        {
            return string.Format(message, GetModelTypeShortName(modelType));
        }

        private static string GetModelTypeShortName(Type modelType)
        {
            const string modelSuffix = "Model";
            string modelTypeName = modelType.Name;
            if (!modelTypeName.EndsWith(modelSuffix))
            {
                return modelTypeName;
            }
            return modelTypeName.Replace(modelSuffix, string.Empty);
        }
    }
}
