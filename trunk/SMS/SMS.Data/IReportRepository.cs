using System.Collections.Generic;
using System.Data;
using Core.Common;

namespace SMS.Data
{
    public interface IReportRepository
    {
        DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters);
    }
}