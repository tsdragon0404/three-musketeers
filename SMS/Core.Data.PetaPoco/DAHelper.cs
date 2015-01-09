using System.Collections.Generic;
using System.Linq;

namespace Core.Data.PetaPoco
{
    public static class DAHelper
    {
        public static string ToSqlInClause(this IEnumerable<long> list)
        {
            var result = list.Aggregate("(", (current, item) => current + (item + ","));
            result = result.Remove(result.Length - 1);
            result += ")";

            return result;
        }

        public static string ToSqlInClause(this IEnumerable<string> list)
        {
            var result = list.Aggregate("(", (current, item) => current + ("'" + item + "',"));
            result = result.Remove(result.Length - 1);
            result += ")";

            return result;
        }
    }
}