using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceDetailMap : BaseMap<InvoiceDetail>
    {
        public InvoiceDetailMap()
        {
            Table("InvoiceDetail");
            References(x => x.InvoiceTable).Column("InvoiceTableID");
            Map(x => x.ProductCode);
            Map(x => x.ProductVNName);
            Map(x => x.ProductENName);
            Map(x => x.Quantity);
            Map(x => x.UnitVNName);
            Map(x => x.UnitENName);
            Map(x => x.Price);
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.Comment);
        }
    }
}