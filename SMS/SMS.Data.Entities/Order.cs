using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using SMS.Common.Enums;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class Order : Entity, IAuditableEntity, IBranchEntity
    {
        public virtual string OrderNumber { get; set; }

        public virtual string Comment { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual string CustomerName { get; set; }

        public virtual string CellPhone { get; set; }

        public virtual string Address { get; set; }

        public virtual DateTime? DOB { get; set; }

        public virtual decimal OtherFee { get; set; }

        public virtual string OtherFeeDescription { get; set; }

        public virtual IList<OrderDiscount> OrderDiscounts { get; set; }

        public virtual IList<OrderTable> OrderTables { get; set; }

        public virtual decimal ServiceFee { get; set; }

        public virtual decimal SubTotal
        {
            get
            {
                if (OrderTables == null)
                    return 0;
                return !OrderTables.Any() ? 0 : OrderTables.Sum(x => x.Amount);
            }
        }

        public virtual decimal DiscountAmount
        {
            get
            {
                var result = 0M;
                if (OrderDiscounts != null)
                {
                    foreach (var orderDiscount in OrderDiscounts)
                    {
                        if (orderDiscount.DiscountType == DiscountType.Number)
                            result += orderDiscount.Discount;
                        if (orderDiscount.DiscountType == DiscountType.Percent)
                            result += (SubTotal + OtherFee + ServiceFee)*orderDiscount.Discount/100;
                    }
                }
                return result;
            }
        }

        public virtual decimal OrderAmount
        {
            get { return SubTotal + OtherFee + ServiceFee - DiscountAmount; }
        }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
