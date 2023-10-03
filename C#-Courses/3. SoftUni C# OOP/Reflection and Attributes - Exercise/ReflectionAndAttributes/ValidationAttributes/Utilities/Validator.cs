using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType))).ToArray();

            foreach (var validationProp in properties)
            {
                object[] cusstomAttriburess = validationProp.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType())).ToArray();
                //CustomAttributeData[] customAttributes = validationProp.CustomAttributes.ToArray();

                object propValue = validationProp.GetValue(obj);
                foreach (object customAttribute in cusstomAttriburess)
                {
                    
                    MethodInfo isValidInfo = customAttribute.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(mi => mi.Name == "IsValid");
                    if (isValidInfo == null)
                    {
                        throw new InvalidOperationException("Your custom attribute does not have IsValid method!");
                    }

                   
                    bool result = (bool)isValidInfo.Invoke(customAttribute, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
