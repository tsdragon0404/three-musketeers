using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceMap : BaseMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice");
            Map(x => x.BranchID);
            Map(x => x.InvoiceNumber);
            Map(x => x.InvoiceDate);
            Map(x => x.Comment);
            Map(x => x.CustomerID);
            Map(x => x.UserID);
            Map(x => x.Tax);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            Map(x => x.Currency);
        }
    }
}