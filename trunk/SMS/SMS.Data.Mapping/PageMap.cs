using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Table("Page");
            Id(x => x.ID).Column("PageID");
            Map(x => x.VNTitle).Not.Update();
            Map(x => x.ENTitle).Not.Update();
            Map(x => x.VNDescription).Not.Update();
            Map(x => x.ENDescription).Not.Update();
            Map(x => x.Path).Not.Update();
            HasMany(x => x.PageLabels).KeyColumn("PageLabelID").Inverse();
        }
    }
}