using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShortCircuit
{
    public static class Utils
    {
        public static List<T> GetEnumValues<T>()
        {
            try
            {
                var currentEnum = typeof (T);
                var resultSet = new List<T>();

                if (currentEnum.IsEnum)
                {
                    var fields = currentEnum.GetFields(BindingFlags.Static | BindingFlags.Public);
                    resultSet.AddRange(fields.Select(field => (T) field.GetValue(null)));
                }
                else
                    throw new ArgumentException("The argument must of type Enum or of a type derived from Enum", "T");

                return resultSet;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return null;
            }
        }
    }
}
