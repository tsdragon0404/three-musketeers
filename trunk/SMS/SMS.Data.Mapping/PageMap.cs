﻿using FluentNHibernate.Mapping;
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
            Map(x => x.Path);
            HasMany(x => x.PageLabels).KeyColumn("PageLabelID");
        }
    }
}