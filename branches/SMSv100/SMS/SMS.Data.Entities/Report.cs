using System.Collections.Generic;

namespace SMS.Data.Entities
{
    public class Report : Entity
    {
        public virtual string Name { get; set; }

        public virtual string VNTitle { get; set; }

        public virtual string ENTitle { get; set; }

        public virtual IList<ReportDatasource> ReportDatasources { get; set; }
    }
}