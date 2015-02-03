using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("USERBRANCH")]
    [PrimaryKey("ID")]
    public class UserBranch
    {
        public long ID { get; set; }
        public Guid UserID { get; set; }
        public long BranchID { get; set; }
    }
}
