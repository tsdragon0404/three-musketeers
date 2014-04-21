﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class InvoiceDetailMap : BaseMap<InvoiceDetail>
    {
        public InvoiceDetailMap()
        {
            Table("InvoiceDetail");
            Map(x => x.InvoiceTableID);
            References(x => x.InvoiceTable).Column("InvoiceTableID");
            Map(x => x.ProductCode);
            Map(x => x.ProductVNName);
            Map(x => x.ProductENName);
            Map(x => x.Quantity);
            Map(x => x.UnitVNName);
            Map(x => x.UnitENName);
            Map(x => x.Price);
            Map(x => x.Discount);
            Map(x => x.DiscountType);
            Map(x => x.DiscountCode);
            Map(x => x.Comment);
        }
    }
}