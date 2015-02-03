using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("ORDERDETAIL")]
    [PrimaryKey("ID")]
    public class OrderDetail
    {
        public long ID { get; set; }
        public long OrderTableID { get; set; }
        public long ProductID { get; set; }
        public decimal Quantity { get; set; }
        public string Comment { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountComment { get; set; }
        public string KitchenComment { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
