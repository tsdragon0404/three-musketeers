using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageLabelMap : BaseMap<PageLabel>
    {
        public PageLabelMap()
        {
            Table("PageLabel");
            Map(x => x.VNText);
            Map(x => x.ENText);
            Map(x => x.LabelID);
            Map(x => x.BranchID);
            References(x => x.Page).Column("PageID").Not.LazyLoad().Not.Update();
        }
    }
}