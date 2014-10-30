using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ReportService : BaseService<ReportDto, IReportManagement>, IReportService
    {
        #region Fields

        #endregion

        //public ServiceResult<DataSet> LoadReportDatasources(string reportName, Dictionary<string, string> queryString)
        //{
        //    return Management.LoadReportDatasources(reportName, queryString);
        //}
    }
}