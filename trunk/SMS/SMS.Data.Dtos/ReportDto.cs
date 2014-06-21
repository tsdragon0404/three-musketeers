using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class ReportDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string VNTitle { get; set; }
        public virtual string ENTitle { get; set; }
        public virtual IList<ReportDatasourceDto> ReportDatasources { get; set; }
    }
}