namespace SMS.Data.Entities
{
    public class RolePermission : Entity
    {
        public virtual long RoleID { get; set; }

        public virtual long PageID { get; set; } 
    }
}