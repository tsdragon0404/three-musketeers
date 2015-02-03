using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("USERSINROLE")]
    [PrimaryKey("ID")]
    public class UsersInRole
    {
        public long ID { get; set; }
        public Guid UserID { get; set; }
        public long RoleID { get; set; }
    }
}