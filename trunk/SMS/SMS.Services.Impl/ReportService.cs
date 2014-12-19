using System.Collections.Generic;
using System.Data;
using Core.Common;
using SMS.Business;

namespace SMS.Services.Impl
{
    public class ReportService : IReportService
    {
        #region Fields

        public virtual IReportManagement Management { get; set; }

        #endregion

        public DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters)
        {
            return Management.ExecuteStoredProcedure(spName, parameters);
        }
    }
}