using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ReportMap : BaseMap<Report>
    {
        public ReportMap()
        {
            Table("Report");
            Map(x => x.Name);
            Map(x => x.VNTitle);
            Map(x => x.ENTitle);
            HasMany(x => x.ReportDatasources)
                .KeyColumn("ReportID")
                .Not.LazyLoad()
                .Inverse();
        }
    }
}