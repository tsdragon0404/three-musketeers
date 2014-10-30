using System.Collections.Generic;
using System.Data;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IReportService : IBaseService<ReportDto, long>
    {
        ServiceResult<DataSet> LoadReportDatasources(string reportName, Dictionary<string, string> queryString);
    }
}