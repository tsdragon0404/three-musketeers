﻿using System;
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
                var index = reader.GetOrdinal(ordinal);
                object value = null;

                if (propertyInfo.PropertyType == typeof(bool))
                    value = reader.GetBoolean(index);
                else if (propertyInfo.PropertyType == typeof (int))
                    value = reader.GetInt32(index);
                else if (propertyInfo.PropertyType == typeof (string))
                    value = reader.GetString(index);
                else if (propertyInfo.PropertyType == typeof (decimal))
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
