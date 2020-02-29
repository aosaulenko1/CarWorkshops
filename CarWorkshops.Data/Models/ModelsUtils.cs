using CarWorkshops.Data.Models.Abstracts;

namespace CarWorkshops.Data.Models
{
    public static class ModelsUtils
    {
        public static bool GetIsValueUnique(IModel model1, IModel model2, object value1, object value2)
        {
            return !model1.Id.Equals(model2.Id) && (value1 == null && value2 == null || value1.Equals(value2));
        }
    }
}
