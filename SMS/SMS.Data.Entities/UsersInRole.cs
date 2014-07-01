namespace SMS.Data.Entities
{
    public class UsersInRole: Entity
    {
        public virtual long UserID { get; set; }

        public virtual long RoleID { get; set; } 
    }
}