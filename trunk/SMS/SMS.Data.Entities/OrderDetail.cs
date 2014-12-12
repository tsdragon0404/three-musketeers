using System;
using Core.Data;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class OrderDetail : Entity, IAuditableEntity
    {
        public virtual OrderTable OrderTable { get; set; }

        public virtual Product Product { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual string Comment { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }

        public virtual string KitchenComment { get; set; }

        public virtual decimal SubTotal
        {
            get { return Quantity * Product.Price; }
        }

        public virtual decimal DiscountAmount
        {
            get { return DiscountType == DiscountType.Number ? Discount : SubTotal * Discount/100; }
        }

        public virtual decimal Amount
        {
            get { return Quantity * Product.Price - DiscountAmount; }
        }

        public virtual OrderStatus OrderStatus { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
