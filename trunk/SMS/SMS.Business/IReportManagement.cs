using System.Collections.Generic;
using System.Data;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IReportManagement : IBaseManagement<ReportDto>
    {
        //ServiceResult<DataSet> LoadReportDatasources(string reportName, Dictionary<string, string> queryString);
    }
}