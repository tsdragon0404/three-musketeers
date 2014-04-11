using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceDetailMap : BaseMap<InvoiceDetail>
    {
        public InvoiceDetailMap()
        {
            Table("InvoiceDetail");
            Map(x => x.InvoiceTableID);
            Map(x => x.ProductCode);
            Map(x => x.ProductName);
            Map(x => x.Quantity);
            Map(x => x.Price);
            Map(x => x.Discount);
            Map(x => x.DiscountType);
            Map(x => x.DiscountCode);
            Map(x => x.Comment);
        }
    }
}