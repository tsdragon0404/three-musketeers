﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceTableMap : BaseMap<InvoiceTable>
    {
        public InvoiceTableMap()
        {
            Table("Invoice");
            Map(x => x.InvoiceID);
            Map(x => x.TableID);
            Map(x => x.Discount);
            Map(x => x.DiscountType);
            Map(x => x.DiscountCode);
            Map(x => x.Comment);
            Map(x => x.Tax);
            Map(x => x.ServiceFee);
            Map(x => x.OtherFee);
            Map(x => x.OtherFeeDescription);
            Map(x => x.TableAmount);
        }
    }
}