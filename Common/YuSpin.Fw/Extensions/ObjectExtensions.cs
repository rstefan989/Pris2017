using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YuSpin.Fw.Extensions
{
    public static class ObjecExtensions
    {
        public static IDictionary<string, string> AnonymousObjectToDictionary(this object obj)
        {
            return obj.AnonymousObjectToDictionary(x => x != null ? x.ToString() : string.Empty);
        }

        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> obj)
        {
            var sb = new StringBuilder();
            foreach (var v in obj)
            {
                sb.Append(v.Key + "=" + v.Value + "&");
            }

            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public static IDictionary<string, T> AnonymousObjectToDictionary<T>(this object obj, Func<object, T> valueSelect)
        {
            return
                TypeDescriptor.GetProperties(obj)
                              .OfType<PropertyDescriptor>()
                              .ToDictionary<PropertyDescriptor, string, T>(
                                  prop => prop.Name.Replace("_", "-"), prop => valueSelect(prop.GetValue(obj)));
        }

        public static IEnumerable<EnumClass> GetItems<TEnum>()
        where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            var res = from e in Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                      select new EnumClass() { Value = Convert.ToInt32(e), Name = e.ToString() };

            return res;
        }

        public static object GetDefault(this object o)
        {
            Func<object> f = GetDefault<object>;
            return f.Method.GetGenericMethodDefinition().MakeGenericMethod(o.GetType()).Invoke(null, null);
        }

        private static T GetDefault<T>()
        {
            return default(T);
        }

        public struct EnumClass
        {
            public int Value { get; set; }
            public string Name { get; set; }
        }
    }
}
