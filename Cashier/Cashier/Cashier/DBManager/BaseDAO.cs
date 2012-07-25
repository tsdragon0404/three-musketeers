using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace Cashier.DBManager
{
    public class BaseDAO
    {
        #region Command Methods

        protected DataSet GetDataSet(SqlDatabase dbManager, string spName, FilterParameterCollection _paramaters)
        {
            try
            {
                DbCommand command = dbManager.GetStoredProcCommand(spName);
                foreach (FilterParameter param in _paramaters)
                {
                    dbManager.AddInParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), param.ParamaterValue);
                }

                DataSet dataList = dbManager.ExecuteDataSet(command);

                return dataList;
            }
            catch (Exception ex)
            {
               // AS.Common.Logger.LoggerManager.Error(spName + " " + _paramaters.ToStringWithParamInfo() + Environment.NewLine + ex.ToString());
                throw;
            }
        }

        protected IDataReader GetDataReader(SqlDatabase dbManager, string spName, FilterParameterCollection _paramaters)
        {
            try
            {
                DbCommand command = dbManager.GetStoredProcCommand(spName);


                foreach (FilterParameter param in _paramaters)
                {
                    dbManager.AddInParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), param.ParamaterValue);
                }

                var dataList = dbManager.ExecuteReader(command);

                return dataList;
            }
            catch (Exception ex)
            {
                //AS.Common.Logger.LoggerManager.Error(spName + " " + _paramaters.ToStringWithParamInfo() + Environment.NewLine + ex.ToString());
                throw;
            }
        }

        protected DataSet ExecuteQueryCommand(SqlDatabase dbManager, string spName, FilterParameterCollection _paramaters, out FilterParameterCollection outParamsList)
        {
            outParamsList = new FilterParameterCollection();
            try
            {
                DbCommand command = dbManager.GetStoredProcCommand(spName);

                foreach (FilterParameter param in _paramaters)
                {
                    if (param.IsOutParameter) dbManager.AddOutParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), 100);
                    else dbManager.AddInParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), param.ParamaterValue);
                }
                DataSet ds = dbManager.ExecuteDataSet(command);
                FilterParameter outParam = null;
                foreach (FilterParameter param in _paramaters)
                {
                    if (!param.IsOutParameter) continue;

                    // get output values and set to parameter value
                    outParam = param.Clone();
                    outParam.ParamaterValue = dbManager.GetParameterValue(command, param.ParamaterName);
                    outParamsList.Add(outParam);
                }
                return ds;
            }
            catch (Exception ex)
            {
                //AS.Common.Logger.LoggerManager.Error(spName + " " + _paramaters.ToStringWithParamInfo() + Environment.NewLine + ex.ToString());
                throw;
            }
        }

        protected int ExecuteNonQueryCommand(SqlDatabase dbManager, string spName, FilterParameterCollection _paramaters, out FilterParameterCollection outParamsList)
        {
            outParamsList = new FilterParameterCollection();
            try
            {
                DbCommand command = dbManager.GetStoredProcCommand(spName);

                foreach (FilterParameter param in _paramaters)
                {
                    if (param.IsOutParameter) dbManager.AddOutParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), 100);
                    else dbManager.AddInParameter(command, param.ParamaterName, (SqlDbType)Enum.ToObject(typeof(SqlDbType), param.ParamaterType), param.ParamaterValue);
                }
                int AffectedRows = dbManager.ExecuteNonQuery(command);
                FilterParameter outParam = null;
                foreach (FilterParameter param in _paramaters)
                {
                    if (!param.IsOutParameter) continue;

                    // get output values and set to parameter value
                    outParam = param.Clone();
                    outParam.ParamaterValue = dbManager.GetParameterValue(command, param.ParamaterName);
                    outParamsList.Add(outParam);
                }
                return AffectedRows;
            }
            catch (Exception ex)
            {
                //AS.Common.Logger.LoggerManager.Error(spName + " " + _paramaters.ToStringWithParamInfo() + Environment.NewLine + ex.ToString());
                throw;
            }
        }

        #endregion
    }
}
