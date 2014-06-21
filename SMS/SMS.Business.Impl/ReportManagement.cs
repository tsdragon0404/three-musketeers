using System.Collections.Generic;
using System.Data;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class ReportManagement : BaseManagement<ReportDto, Report, long, IReportRepository>, IReportManagement
    {
        #region Fields

        #endregion

        public ServiceResult<DataSet> LoadReportDatasources(string reportName)
        {
            var report = Repository.FindOne(x => x.Name == reportName);
            if(report == null)
            {
                return new ServiceResult<DataSet> { Errors = new List<ValidationError> { new ValidationError("Report name", "Report name is not valid") } };
            }

            var returnData = new DataSet("reportDataSet");
            
            foreach (var reportDatasource in report.ReportDatasources)
            {
                var reportData = (DataTable)Repository.ExecuteStoredProcedure(reportDatasource.Name);
                reportData.TableName = reportDatasource.Name;
                returnData.Tables.Add(reportData);
            }

            return new ServiceResult<DataSet> { Data = returnData };
        }
    }
}