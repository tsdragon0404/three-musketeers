using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class PageMenuMap : BaseMap<PageMenu>
    {
        public PageMenuMap()
        {
            Table("PageMenu");
            Map(x => x.GroupName);
            Map(x => x.PageID);
            Map(x => x.ParentID);
        }
    }
}