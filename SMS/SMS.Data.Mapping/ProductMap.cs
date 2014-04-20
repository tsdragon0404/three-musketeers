using FluentNHibernate.Mapping;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Map(x => x.ProductCode);
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.VNDescription);
            Map(x => x.ENDescription);
            Map(x => x.UnitID);
            References(x => x.Unit).Column("UnitID").Not.LazyLoad();
            Map(x => x.ProductCategoryID);
            References(x => x.ProductCategory).Column("ProductCategoryID");
            Map(x => x.Price);
            Map(x => x.Enable);
        }
    }
}