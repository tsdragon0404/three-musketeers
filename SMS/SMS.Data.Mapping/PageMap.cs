using FluentNHibernate.Mapping;
using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Table("Page");
            Id(x => x.ID).Column("PageID");
            Map(x => x.VNTitle);
            Map(x => x.ENTitle);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            Map(x => x.Type).CustomType<PageType>().Not.Update();
            Map(x => x.Area).Not.Update();
            Map(x => x.Controller).Not.Update();
            Map(x => x.Action).Not.Update();
            HasMany(x => x.PageLabels).KeyColumn("PageLabelID").Inverse();
        }
    }
}