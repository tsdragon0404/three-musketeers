using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("ORDERTABLE")]
    [PrimaryKey("ID")]
    public class OrderTable
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public long TableID { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountComment { get; set; }
        public bool UseServiceFee { get; set; }
        public decimal OtherFee { get; set; }
        public string OtherFeeDescription { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
