using System.Collections.Generic;
using System.Data;
using Core.Common;

namespace SMS.Business
{
    public interface IReportManagement
    {
        DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters);
    }
}