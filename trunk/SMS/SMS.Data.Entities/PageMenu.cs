namespace SMS.Data.Entities
{
    public class PageMenu : Entity
    {
        public virtual string GroupName { get; set; }

        public virtual long PageID { get; set; }
    }
}