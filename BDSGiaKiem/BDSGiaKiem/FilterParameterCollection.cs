using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace BDSGiaKiem
{
    public class FilterParameterCollection: CollectionBase, ICloneable
    {
                
            public FilterParameterCollection()
            {

            }
            public FilterParameter this[int index]
            {
                get { return ((FilterParameter)List[index]); }
                set { List[index] = value; }
            }

            /// <summary>
            /// Adds the specified FilterParameter object.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns>The index of FilterParameter object.</returns>
            public int Add(FilterParameter value)
            {
                return (List.Add(value));
            }

            /// <summary>
            /// Adds the specified parameter name.
            /// </summary>
            /// <param name="parameterName">Name of the parameter.</param>
            /// <param name="parameterValue">The parameter value.</param>
            /// <param name="parameterType">Type of the parameter.</param>
            /// <returns>The index of FilterParameter object.</returns>
            public FilterParameterCollection Add(string parameterName, object parameterValue, object parameterType)
            {
                var parameter = new FilterParameter
                {
                    ParamaterName = parameterName,
                    ParamaterValue = parameterValue,
                    ParamaterType = parameterType
                };
                List.Add(parameter);

                return this;
            }

            /// <summary>
            /// Adds the specified parameter name.
            /// </summary>
            /// <param name="parameterName">Name of the parameter.</param>
            /// <param name="parameterValue">The parameter value.</param>
            /// <param name="parameterType">Type of the parameter.</param>
            /// <param name="isOutParameter">if true, this parameter is out parameter.</param>
            /// <returns>The index of FilterParameter object.</returns>
            public FilterParameterCollection Add(string parameterName, object parameterValue, object parameterType, bool isOutParameter)
            {
                var parameter = new FilterParameter
                {
                    ParamaterName = parameterName,
                    ParamaterValue = parameterValue,
                    ParamaterType = parameterType,
                    IsOutParameter = isOutParameter
                };
                List.Add(parameter);

                return this;
            }

            public int IndexOf(FilterParameter value)
            {
                return (List.IndexOf(value));
            }

            public void Insert(int index, FilterParameter value)
            {
                List.Insert(index, value);
            }

            public void Remove(FilterParameter value)
            {
                if (value != null)
                    List.Remove(value);
            }

            public bool Contains(FilterParameter value)
            {
                // If value is not of type Test, this will return false.
                return (List.Contains(value));
            }

            public FilterParameter FindFilterParameterByName(string paramName, bool isCaseSensitive)
            {
                for (int i = 0; i < List.Count; i++)
                {
                    FilterParameter param = (FilterParameter)List[i];
                    if (string.Compare(param.ParamaterName, paramName, isCaseSensitive) == 0) return param;
                }

                return null;
            }

            public string ToStringWithParamInfo()
            {
                StringBuilder Temp = new StringBuilder();
                foreach (FilterParameter p in this.List)
                {
                    Temp.Append(string.Format("{0}={1}; ", p.ParamaterName, p.ParamaterValue));
                }
                return Temp.ToString();
            }

            /// <summary>
            /// Clones the collection.
            /// </summary>
            /// <returns></returns>
            public FilterParameterCollection CloneCollection()
            {

                FilterParameterCollection list = new FilterParameterCollection();
                for (int i = 0; i < List.Count; i++)
                    list.Add((FilterParameter)List[i]);

                return list;
            }

            /// <summary>
            /// Adds the parameter for paging interface.
            /// </summary>
            /// <param name="isPaging">if set to <c>true</c> [is paging].</param>
            /// <param name="isCountPageTotal">if set to <c>true</c> [is count page total].</param>
            /// <param name="pageNo">The page no.</param>
            /// <param name="pageSize">Size of the page.</param>
            /// <param name="orderExp">The order exp.</param>
            /// <param name="filterExp">The filter exp.</param>
            public void AddPagingParameters(
                bool isPaging, bool isCountPageTotal, int pageNo, int pageSize, string orderExp, string filterExp)
            {
                this.Add(new FilterParameter { ParamaterName = "@IsPaging", ParamaterValue = isPaging, ParamaterType = DbType.Boolean });
                this.Add(new FilterParameter { ParamaterName = "@IsCountPageTotal", ParamaterValue = isCountPageTotal, ParamaterType = DbType.Boolean });
                this.Add(new FilterParameter { ParamaterName = "@PageNo", ParamaterValue = pageNo, ParamaterType = DbType.Int32 });
                this.Add(new FilterParameter { ParamaterName = "@PageSize", ParamaterValue = pageSize, ParamaterType = DbType.Int32 });
                this.Add(new FilterParameter { ParamaterName = "@stOrder", ParamaterValue = orderExp, ParamaterType = DbType.AnsiString });
                this.Add(new FilterParameter { ParamaterName = "@stFilter", ParamaterValue = filterExp, ParamaterType = DbType.AnsiString });
            }

            /// <summary>
            /// Clears the paging parameters.
            /// </summary>
            public void ClearPagingParameters()
            {
                FilterParameter fp = this.FindFilterParameterByName("@IsPaging", false);
                this.Remove(fp);
                fp = this.FindFilterParameterByName("@IsCountPageTotal", false);
                this.Remove(fp);
                fp = this.FindFilterParameterByName("@PageNo", false);
                this.Remove(fp);
                fp = this.FindFilterParameterByName("@PageSize", false);
                this.Remove(fp);
                fp = this.FindFilterParameterByName("@stOrder", false);
                this.Remove(fp);
                fp = this.FindFilterParameterByName("@stFilter", false);
                this.Remove(fp);
            }


            #region ICloneable Members

            /// <summary>
            /// Creates a new object that is a copy of the current instance.
            /// </summary>
            /// <returns>
            /// A new object that is a copy of this instance.
            /// </returns>
            public object Clone()
            {
                return CloneCollection();
            }

            #endregion
        }

}
