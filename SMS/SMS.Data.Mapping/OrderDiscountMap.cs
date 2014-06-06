﻿using SMS.Common.Constant;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class OrderDiscountMap : BaseMap<OrderDiscount>
    {
        public OrderDiscountMap()
        {
            Table("OrderDiscount");
            References(x => x.Order).Column("OrderID");
            Map(x => x.Discount);
            Map(x => x.DiscountType).CustomType<DiscountType>();
            Map(x => x.DiscountCode);
            Map(x => x.DiscountComment);
        }
    }
}