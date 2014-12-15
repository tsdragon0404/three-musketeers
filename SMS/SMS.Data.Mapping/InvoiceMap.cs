using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceMap : BaseMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice");
            References(x => x.Branch).Column("BranchID").Cascade.None();
            Map(x => x.InvoiceNumber);
            Map(x => x.InvoiceDate);
            Map(x => x.InvoiceCreatedBy);
            Map(x => x.Comment);
            Map(x => x.CustomerID);
            Map(x => x.CustomerName);
            Map(x => x.Address);
            Map(x => x.CellPhone);
            Map(x => x.DOB);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            Map(x => x.TaxInfo);
            Map(x => x.Currency);
            Map(x => x.PaymentMethod).CustomType<PaymentMethod>();
            Map(x => x.TaxAmount);
            Map(x => x.DiscountAmount);
            Map(x => x.InvoiceAmount);
            HasMany(x => x.InvoiceDiscounts).KeyColumn("InvoiceID").Cascade.AllDeleteOrphan();
            HasMany(x => x.InvoiceTables).KeyColumn("InvoiceID").Cascade.AllDeleteOrphan();
        }
    }
}