using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceDiscountMap : BaseMap<InvoiceDiscount>
    {
        public InvoiceDiscountMap()
        {
            Table("InvoiceDiscount");
            Map(x => x.InvoiceID);
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.DiscountComment);
        }
    }
}
