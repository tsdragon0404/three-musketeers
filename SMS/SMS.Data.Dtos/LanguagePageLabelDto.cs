namespace SMS.Data.Dtos
{
    public class LanguagePageLabelDto
    {
        public virtual long ID { get; set; }
        public virtual string LabelID { get; set; }
        public virtual PageDto Page { get; set; }
        public virtual string Text { get; set; }
    }
}