namespace SMS.Data.Dtos
{
    public class PageBasicDto
    {
        public virtual long ID { get; set; }
        public virtual string Area { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
    }
}