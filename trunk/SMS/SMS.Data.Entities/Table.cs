using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("TABLE")]
    [PrimaryKey("ID")]
    public class Table
    {
        public long ID { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
        public long AreaID { get; set; }
        public bool Enable { get; set; }
        public int SEQ { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}