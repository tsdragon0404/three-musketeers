using System.Collections.Generic;
using System.Linq;

namespace Core.Data.PetaPoco
{
    public static class DAHelper
    {
        public static List<T> Select<T>(IConfig config, string cmd, params object[] args)
        {
            var db = new Database(config);
            return db.Query<T>(cmd, args).ToList();
        }

        public static T SelectOne<T>(IConfig config, string cmd, params object[] args)
        {
            var db = new Database(config);
            return db.SingleOrDefault<T>(cmd, args);
        }

        public static T Save<T>(IConfig config, T obj)
        {
            var db = new Database(config);
            db.Save(obj);
            return obj;
        }

        public static bool Delete<T>(IConfig config, object primaryKey)
        {
            var db = new Database(config);
            return db.Delete<T>(primaryKey) > 0;
        }

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

        public static string ToSqlValue(this bool value)
        {
            return value ? "1" : "0";
        }
    }
}