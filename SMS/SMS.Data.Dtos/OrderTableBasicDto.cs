namespace SMS.Data.Dtos
{
    public class OrderTableBasicDto
    {
        public virtual long ID { get; set; }
        public virtual OrderBasicDto Order { get; set; }
        public virtual LanguageTableDto Table { get; set; }
    }
}
