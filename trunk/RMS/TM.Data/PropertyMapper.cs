using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TM.Utilities;

namespace TM.Data
{
    public static class PropertyMapper
    {
        public static IEnumerable<TEntity> Map<TEntity>(this IDataReader reader) where TEntity : new()
        {
            using (reader)
            {
                while (reader.Read())
                {
                    var result = new TEntity();
                    foreach (var propertyInfo in result.GetType().GetProperties())
                    {
                        var dataFieldAtt = propertyInfo.GetAttributes<DataFieldAttribute>(true).ToList();
                        var ordinal = propertyInfo.Name;

                        if (dataFieldAtt.Any())
                        {
                            var attribute = dataFieldAtt[0];
                            if (attribute != null)
                                ordinal = attribute.Name;
                        }

                        SetPropertyValue(propertyInfo, result, reader, ordinal);
                    }

                    yield return result;
                }
            }
        }

        public static IEnumerable<TEntity> Map<TEntity>(this DataTable dataTable) where TEntity : new()
        {
            var reader = dataTable.CreateDataReader();
            return Map<TEntity>(reader);
        }

        private static void SetPropertyValue(PropertyInfo propertyInfo, object target, IDataRecord reader, string ordinal)
        {
            try
            {
                if (propertyInfo.PropertyType == typeof (int))
                    propertyInfo.SetValue(target, reader.GetInt32(reader.GetOrdinal(ordinal)));
                if (propertyInfo.PropertyType == typeof (string))
                    propertyInfo.SetValue(target, reader.GetString(reader.GetOrdinal(ordinal)));
                if (propertyInfo.PropertyType == typeof (decimal))
                    propertyInfo.SetValue(target, reader.GetDecimal(reader.GetOrdinal(ordinal)));
            }
            catch
            {
                propertyInfo.SetValue(target, null);                
            }
        }
    }
}
