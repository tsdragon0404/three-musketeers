using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TM.Utilities;

namespace TM.Data.Mapping
{
    public static class PropertyMapper
    {
        /// <summary>
        /// Maps to an IEnumerable of TEntity from a DataReader.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public static IEnumerable<TEntity> Map<TEntity>(this IDataReader reader) where TEntity : new()
        {
            using (reader)
            {
                while (reader.Read())
                {
                    var result = new TEntity();
                    foreach (var propertyInfo in result.GetType().GetProperties())
                    {
                        var dataFieldAtt = propertyInfo.GetCustomAttribute<DataFieldAttribute>();

                        if (dataFieldAtt == null) continue;

                        var ordinal = dataFieldAtt.Name;
                        SetPropertyValue(propertyInfo, result, reader, ordinal);
                    }

                    yield return result;
                }
            }
        }

        /// <summary>
        /// Maps the specified data table to an IEnumerable of TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static IEnumerable<TEntity> Map<TEntity>(this DataTable dataTable) where TEntity : new()
        {
            var reader = dataTable.CreateDataReader();
            return Map<TEntity>(reader);
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="target">The target.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        private static void SetPropertyValue(PropertyInfo propertyInfo, object target, IDataRecord reader, string ordinal)
        {
            try
            {
                var index = reader.GetOrdinal(ordinal);
                object value = null;

                if (propertyInfo.PropertyType == typeof(bool))
                    value = reader.GetBoolean(index);
                else if (propertyInfo.PropertyType == typeof(int) || (propertyInfo.PropertyType == typeof(Int32)))
                    value = reader.GetInt32(index);
                else if (propertyInfo.PropertyType == typeof(Int16))
                    value = reader.GetInt16(index);
                else if (propertyInfo.PropertyType == typeof(Byte))
                    value = reader.GetByte(index);
                else if (propertyInfo.PropertyType == typeof(Int64))
                    value = reader.GetInt64(index);
                else if (propertyInfo.PropertyType == typeof(string))
                    value = reader.GetString(index);
                else if (propertyInfo.PropertyType == typeof(decimal))
                    value = reader.GetDecimal(index);
                else if (propertyInfo.PropertyType == typeof(DateTime))
                    value = reader.GetDateTime(index);
                else if (propertyInfo.PropertyType == typeof(Guid))
                    value = reader.GetGuid(index);

                if(value != null)
                    propertyInfo.SetValue(target, value);
            }
            catch
            {
                propertyInfo.SetValue(target, null);                
            }
        }
    }
}
