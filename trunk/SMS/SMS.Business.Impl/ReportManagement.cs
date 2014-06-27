using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public ServiceResult<DataSet> LoadReportDatasources(string reportName, Dictionary<string, string> queryString)
        {
            var report = Repository.FindOne(x => x.Name == reportName);
            if(report == null)
                return ServiceResult<DataSet>.CreateFailResult(new ValidationError("Report name", "Report name is not valid"));

            var returnData = new DataSet(Common.Constant.ConstReport.ReportDataSetName);
            
            foreach (var reportDatasource in report.ReportDatasources)
            {
                var parameters = reportDatasource.ReportDatasourceParameters.ToDictionary(x => x.Name, y => queryString.ContainsKey(y.Name) ? queryString[y.Name] : null);
                var reportData = (DataTable)Repository.ExecuteStoredProcedure(reportDatasource.Name, parameters);
                reportData.TableName = reportDatasource.Name;
                returnData.Tables.Add(reportData);
            }

            return ServiceResult<DataSet>.CreateSuccessResult(returnData);
        }
    }
}