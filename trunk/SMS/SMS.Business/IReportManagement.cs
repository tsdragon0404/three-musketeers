using System.Collections.Generic;
using System.Data;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IReportManagement : IBaseManagement<ReportDto, long>
    {
        ServiceResult<DataSet> LoadReportDatasources(string reportName);
    }
}