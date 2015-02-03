using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("ROLE")]
    [PrimaryKey("ID")]
    public class Role
    {
        public long ID { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public long BranchID { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}