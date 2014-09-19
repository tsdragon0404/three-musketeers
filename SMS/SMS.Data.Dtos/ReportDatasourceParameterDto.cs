using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class ReportDatasourceParameterDto
    {
        public virtual string Name { get; set; }
        public virtual ReportDatasourceParameterType Type { get; set; }
        public virtual ReportDatasourceDto ReportDatasource { get; set; }
    }
}