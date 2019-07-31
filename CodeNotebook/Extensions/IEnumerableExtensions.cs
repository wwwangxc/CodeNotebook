using System;
using System.Collections.Generic;
using System.Text;

namespace CodeNotebook.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> collection, string separator, string propertyName = null)
        {
            var tType = typeof(T);
            var stringBuilder = new StringBuilder();

            foreach (var item in collection)
            {
                if(item is string || tType.IsValueType || string.IsNullOrWhiteSpace(propertyName))
                {
                    stringBuilder.Append(item.ToString());
                }
                else
                {
                    var property = typeof(T).GetProperty(propertyName);
                    var valueObj = property.GetValue(item, null);
                    if (valueObj == null) continue;

                    var value = valueObj.ToString();
                    if (string.IsNullOrWhiteSpace(value)) continue;

                    stringBuilder.Append(value);
                }

                stringBuilder.Append(separator);
            }

            return stringBuilder.Length == 0 ? 
                string.Empty : stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
        }
    }
}
