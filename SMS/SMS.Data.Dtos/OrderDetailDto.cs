﻿using System;
using SMS.Common.Enums;

namespace SMS.Data.Dtos
{
    public class OrderDetailDto : OrderDetailBasicDto
    {
        public virtual OrderTableDto OrderTable { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }

    public class LanguageOrderDetailDto : OrderDetailBasicDto
    {
        public virtual LanguageProductDto Product { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal Amount { get; set; }
    }

    public class OrderDetailForKitchen
    {
        public virtual long ID { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string Comment { get; set; }
        public virtual string KitchenComment { get; set; }
        public virtual ProductForKitchenDto Product { get; set; }
        public virtual OrderTableForKitchenDto OrderTable { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }

    public class OrderDetailBasicDto
    {
        public virtual long ID { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual string KitchenComment { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
