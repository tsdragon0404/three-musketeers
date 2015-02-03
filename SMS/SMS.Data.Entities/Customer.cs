using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("CUSTOMER")]
    [PrimaryKey("ID")]
    public class Customer
    {
        public long ID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public DateTime? DOB { get; set; }
        public long? BranchID { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
