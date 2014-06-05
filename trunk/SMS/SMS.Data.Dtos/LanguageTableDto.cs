namespace SMS.Data.Dtos
{
    public class LanguageTableDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual LanguageAreaDto Area { get; set; }
    }
}
