using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageLabelMap : BaseMap<PageLabel>
    {
        public PageLabelMap()
        {
            Table("Page");
            Map(x => x.VNText);
            Map(x => x.ENText);
            Map(x => x.LabelID);
            References(x => x.Page).Column("PageID");
        }
    }
}