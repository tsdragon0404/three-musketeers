using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ReportDatasourceMap : BaseMap<ReportDatasource>
    {
        public ReportDatasourceMap()
        {
            Table("ReportDatasource");
            Map(x => x.Name);
            References(x => x.Report).Column("ReportID").Not.LazyLoad();
            HasMany(x => x.ReportDatasourceParameters)
                .KeyColumn("ReportDatasourceID")
                .Not.LazyLoad()
                .Inverse();
        }
    }
}