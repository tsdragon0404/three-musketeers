﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceMap : BaseMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice");
            References(x => x.Branch).Column("BranchID")
                .Cascade.None();
            Map(x => x.InvoiceNumber);
            Map(x => x.InvoiceDate);
            Map(x => x.Comment);
            References(x => x.Customer).Column("CustomerID");
            Map(x => x.CustomerName);
            Map(x => x.Address);
            Map(x => x.CellPhone);
            Map(x => x.DOB);
            Map(x => x.UserID);
            Map(x => x.Tax);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            Map(x => x.Currency);
            HasMany(x => x.InvoiceTables).KeyColumn("InvoiceID").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}