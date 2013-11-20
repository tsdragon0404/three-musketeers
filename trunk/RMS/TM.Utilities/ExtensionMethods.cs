using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace TM.Utilities
{
    public static class ExtensionMethods
    {
        #region Convert extension

        /// <summary>
        /// Convert string to unique identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Guid ToGuid(this String value)
        {
            Guid guidValue;
            var parseResult = Guid.TryParse(value, out guidValue);
            return !parseResult ? Guid.Empty : guidValue;
        }

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this String value)
        {
            DateTime dateTimeValue;
            var parseResult = DateTime.TryParse(value, out dateTimeValue);
            return !parseResult ? null : (DateTime?)dateTimeValue;
        }

        /// <summary>
        /// Convert string to boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert List to observable collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            return new ObservableCollection<T>(list);
        }

        #endregion



        /// <summary>
        /// Applies an action to the specified enumerable.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="action">The action.</param>
        public static void Apply<TElement>(this IEnumerable<TElement> enumerable, Action<TElement> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributes<T>(this MemberInfo memberInfo, bool inherit)
        {
            return Attribute.GetCustomAttributes(memberInfo, inherit).OfType<T>();
        }
    }
}
