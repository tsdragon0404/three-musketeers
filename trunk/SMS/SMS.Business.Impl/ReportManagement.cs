using System.Collections.Generic;
using System.Data;
using Core.Common;
using SMS.Data;

namespace SMS.Business.Impl
{
    public class ReportManagement : IReportManagement
    {
        #region Fields

        public virtual IReportRepository Repository { get; set; }

        #endregion

        public DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters)
        {
            return Repository.ExecuteStoredProcedure(spName, parameters);
        }
    }
}