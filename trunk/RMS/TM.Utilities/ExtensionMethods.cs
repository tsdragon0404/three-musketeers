using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace TM.Utilities
{
    public static class ExtensionMethods
    {
        #region String extension

        public static Guid ToGuid(this String value)
        {
            Guid guidValue;
            var parseResult = Guid.TryParse(value, out guidValue);
            return !parseResult ? Guid.Empty : guidValue;
        }

        public static DateTime? ToDateTime(this String value)
        {
            DateTime dateTimeValue;
            var parseResult = DateTime.TryParse(value, out dateTimeValue);
            return !parseResult ? null : (DateTime?)dateTimeValue;
        }

        public static Boolean ToBoolean(this String value)
        {
            Boolean booleanValue;
            var parseResult = Boolean.TryParse(value, out booleanValue);

            if (!parseResult)
            {
                Int32 intValue;
                parseResult = Int32.TryParse(value, out intValue);

                if (!parseResult) return false;

                return intValue == 1;
            }

            return booleanValue;
        } 

        #endregion

        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        public static void Apply<TElement>(this IEnumerable<TElement> enumerable, Action<TElement> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static IEnumerable<T> GetAttributes<T>(this MemberInfo memberInfo, bool inherit)
        {
            return Attribute.GetCustomAttributes(memberInfo, inherit).OfType<T>();
        }
    }
}
