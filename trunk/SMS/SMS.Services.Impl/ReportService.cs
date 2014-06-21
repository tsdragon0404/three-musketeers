using System.Data;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ReportService : BaseService<ReportDto, long, IReportManagement>, IReportService
    {
        #region Fields

        #endregion

        public ServiceResult<DataSet> LoadReportDatasources(string reportName)
        {
            return Management.LoadReportDatasources(reportName);
        }
    }
}