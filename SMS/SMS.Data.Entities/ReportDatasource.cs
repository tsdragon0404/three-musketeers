using System.Collections.Generic;

namespace SMS.Data.Entities
{
    public class ReportDatasource : Entity
    {
        public virtual string Name { get; set; }

        public virtual Report Report { get; set; }

        public virtual IList<ReportDatasourceParameter> ReportDatasourceParameters { get; set; }
    }
}