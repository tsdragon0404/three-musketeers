namespace SMS.Data.Dtos
{
    public class PageLabelDto
    {
        public virtual long ID { get; set; }
        public virtual string LabelID { get; set; }
        public virtual PageDto Page { get; set; }
        public virtual string VNText { get; set; }
        public virtual string ENText { get; set; }
    }
}