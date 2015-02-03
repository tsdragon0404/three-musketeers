using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("ORDER")]
    [PrimaryKey("ID")]
    public class Order
    {
        public long ID { get; set; }
        public long BranchID { get; set; }
        public string OrderNumber { get; set; }
        public string Comment { get; set; }
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public DateTime? DOB { get; set; }
        public decimal OtherFee { get; set; }
        public string OtherFeeDescription { get; set; }
        public OrderProgressStatus OrderProgressStatus { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
