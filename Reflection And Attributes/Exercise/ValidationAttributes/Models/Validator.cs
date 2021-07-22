using System;
using ValidationAttributes.Attributes;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute attribute = (MyValidationAttribute)property
                    .GetCustomAttribute(typeof(MyValidationAttribute), false);

                if(attribute.IsValid(property.GetValue(obj)) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
