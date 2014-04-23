using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceTableMap : BaseMap<InvoiceTable>
    {
        public InvoiceTableMap()
        {
            Table("InvoiceTable");
            Map(x => x.InvoiceID);
            //References(x => x.Invoice).Column("InvoiceID");
            Map(x => x.TableID);
            //References(x => x.Table).Column("TableID");
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.Comment);
            Map(x => x.Tax);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            Map(x => x.TableAmount);
            HasMany(x => x.InvoiceDetails).KeyColumn("InvoiceTableID").Inverse();
        }
    }
}