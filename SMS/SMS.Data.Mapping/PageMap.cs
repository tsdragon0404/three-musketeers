using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageMap : BaseMap<Page>
    {
        public PageMap()
        {
            Table("Page");
            Map(x => x.VNTitle);
            Map(x => x.ENTitle);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            Map(x => x.Path);
            HasMany(x => x.PageLabels).KeyColumn("PageLabelID");
        }
    }
}