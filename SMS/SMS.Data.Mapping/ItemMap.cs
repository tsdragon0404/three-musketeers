using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ItemMap : BaseMap<Item>
    {
        public ItemMap()
        {
            Table("Item");
            Map(x => x.BranchID);
            Map(x => x.ItemCode);
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            References(x => x.Unit).Column("UnitID").Not.LazyLoad();
            References(x => x.ProductCategory).Column("ProductCategoryID");
            Map(x => x.IsInventory);
            Map(x => x.MinQuantity);
        }
    }
}