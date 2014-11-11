using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class ReportDatasourceDto
    {
        public virtual string Name { get; set; }
        public virtual ReportDto Report { get; set; }
        public virtual IList<ReportDatasourceParameterDto> ReportDatasourceParameters { get; set; }
    }
}