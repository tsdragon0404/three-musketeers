using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Enums;
using SMS.Common.Storage.CacheObjects;

namespace SMS.Data.Dtos
{
    public class OrderDto : OrderDataDto
    {
        public virtual BranchDto Branch { get; set; }
    }

    public class OrderDataDto : OrderBasicDto
    {
        public virtual IList<LanguageOrderTableDto> OrderTables { get; set; }

        public virtual decimal SubTotal
        {
            get { return !OrderTables.Any() ? 0 : OrderTables.Sum(x => x.TableAmount); }
        }

        public virtual decimal DiscountValue
        {
            get
            {
                var result = 0M;
                foreach (var orderDiscount in OrderDiscounts)
                {
                    if (orderDiscount.DiscountType == DiscountType.Number)
                        result += orderDiscount.Discount;
                    if (orderDiscount.DiscountType == DiscountType.Percent)
                        result += (SubTotal + OtherFee + (BranchConfigs.Current.UseServiceFee ? BranchConfigs.Current.ServiceFee : 0)) * orderDiscount.Discount / 100;
                }
                return result;
            }
        }

        public virtual decimal Total
        {
            get { return SubTotal + OtherFee + (BranchConfigs.Current.UseServiceFee ? BranchConfigs.Current.ServiceFee : 0) - DiscountValue; }
        }
    }

    public class OrderBasicDto
    {
        public virtual long ID { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string Comment { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual IList<OrderDiscountDto> OrderDiscounts { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
