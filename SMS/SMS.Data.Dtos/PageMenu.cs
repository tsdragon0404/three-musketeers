namespace SMS.Data.Dtos
{
    public class PageMenuDto
    {
        public virtual long ID { get; set; }
        public virtual string GroupName { get; set; }
        public virtual long PageID { get; set; }
        public virtual long ParentID { get; set; }
        public virtual int SEQ { get; set; }
    }
}