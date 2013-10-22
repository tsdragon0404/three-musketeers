using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TM.Utilities
{
    public static class ExtensionMethods
    {
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

        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
        {
            return new ObservableCollection<T>(list);
        }
    }
}
