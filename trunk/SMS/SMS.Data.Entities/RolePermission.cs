using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("ROLEPERMISSION")]
    [PrimaryKey("ID")]
    public class RolePermission
    {
        public long ID { get; set; }
        public long RoleID { get; set; }
        public long PageID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}