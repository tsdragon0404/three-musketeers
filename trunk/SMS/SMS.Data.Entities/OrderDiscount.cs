using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("ORDERDISCOUNT")]
    [PrimaryKey("ID")]
    public class OrderDiscount
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public string DiscountCode { get; set; }
        public string DiscountComment { get; set; }
    }
}
