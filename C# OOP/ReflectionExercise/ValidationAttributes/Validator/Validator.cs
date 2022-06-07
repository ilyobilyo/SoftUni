using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute))
                .Any())
                .ToArray();

            foreach (var propInfo in propertyInfos)
            {
                object value = propInfo.GetValue(obj);

                MyValidationAttribute attribute = propInfo.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.IsValid(value);

                if (!isValid)
                {
                    return false;
                }
            }


            return true;
        }
    }
}
