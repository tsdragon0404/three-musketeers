using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("USERCONFIG")]
    [PrimaryKey("ID")]
    public class UserConfig
    {
        public long ID { get; set; }
        public Guid UserID { get; set; }
        public long BranchID { get; set; }
        public long DefaultAreaID { get; set; }
        public decimal ListTableHeight { get; set; }
        public int PageSize { get; set; }
        public bool IsSuspended { get; set; }
        public string Theme { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
