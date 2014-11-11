using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ReportDatasourceParameterMap : BaseMap<ReportDatasourceParameter>
    {
        public ReportDatasourceParameterMap()
        {
            Table("ReportDatasourceParameter");
            Map(x => x.Name);
            Map(x => x.Type).CustomType<ReportDatasourceParameterType>();
            References(x => x.ReportDatasource).Column("ReportDatasourceID").Not.LazyLoad();
        }
    }
}