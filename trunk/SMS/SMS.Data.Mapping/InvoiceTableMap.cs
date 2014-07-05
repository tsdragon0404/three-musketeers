using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceTableMap : BaseMap<InvoiceTable>
    {
        public InvoiceTableMap()
        {
            Table("InvoiceTable");
            References(x => x.Invoice).Column("InvoiceID");
            Map(x => x.TableID);
            Map(x => x.TableVNName);
            Map(x => x.TableENName);
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.DiscountComment);
            Map(x => x.Tax);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            HasMany(x => x.InvoiceDetails).KeyColumn("InvoiceTableID").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}