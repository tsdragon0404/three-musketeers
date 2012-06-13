using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BDSGiaKiem
{
    public class BDSDAO : BaseDAO
    {
        private DatabaseName _DatabaseName = DatabaseName.MAIN;
        private DSLSqlDatabase _CurrentDatabase
        {
            get { return DatabaseManager.CreateDatabase(_DatabaseName); }

        }

        public BDSDAO() { }

        public BDSDAO(DatabaseName databaseName)
        {
            _DatabaseName = databaseName;
        }

        public DataTable GetReports(string spName, FilterParameterCollection _paramaters)
        {
            DataSet dataList = base.GetDataSet(_CurrentDatabase, spName, _paramaters);
            if (dataList != null && dataList.Tables.Count > 0)
            {
                return dataList.Tables[0];
            }
            return null;
        }

        public IDataReader GetReportsByDataReader(string spName, FilterParameterCollection _paramaters)
        {
            IDataReader reader = base.GetDataReader(_CurrentDatabase, spName, _paramaters);
            if (reader != null)
            {
                return reader;
            }
            return null;
        }

        public int ExecuteNonQueryCommand(string spName, FilterParameterCollection _paramaters, out FilterParameterCollection OutputParams)
        {
            return base.ExecuteNonQueryCommand(_CurrentDatabase, spName, _paramaters, out OutputParams);
        }

        public DataSet ExecuteQueryCommand(string spName, FilterParameterCollection _paramaters, out FilterParameterCollection OutputParams)
        {
            return base.ExecuteQueryCommand(_CurrentDatabase, spName, _paramaters, out OutputParams);
        }

        public DataSet GetReportsAsDataSet(string spName, FilterParameterCollection _paramaters)
        {
            return base.GetDataSet(_CurrentDatabase, spName, _paramaters);
        }
    }
}
