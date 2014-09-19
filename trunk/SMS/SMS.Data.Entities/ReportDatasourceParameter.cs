using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class ReportDatasourceParameter : Entity
    {
        public virtual string Name { get; set; }

        public virtual ReportDatasourceParameterType Type { get; set; }

        public virtual ReportDatasource ReportDatasource { get; set; }
    }
}