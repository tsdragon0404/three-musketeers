using System.Collections.Generic;
using System.Data;
using Core.Common;

namespace SMS.Services
{
    public interface IReportService
    {
        DataTable ExecuteStoredProcedure(string spName, List<SpParameter> parameters);
    }
}