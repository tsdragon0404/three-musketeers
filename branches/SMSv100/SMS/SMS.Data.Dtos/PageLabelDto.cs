namespace SMS.Data.Dtos
{
    public class PageLabelDto : PageLabelBasicDto
    {
        public virtual PageDto Page { get; set; }
        public virtual string VNText { get; set; }
        public virtual string ENText { get; set; }
    }

    public class LanguagePageLabelDto : PageLabelBasicDto
    {
        public virtual PageDto Page { get; set; }
        public virtual string Text { get; set; }
    }

    public class PageLabelBasicDto
    {
        public virtual long ID { get; set; }
        public virtual string LabelID { get; set; }
        public virtual long BranchID { get; set; }        
    }
}