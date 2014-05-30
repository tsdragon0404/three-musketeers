namespace SMS.Data.Dtos
{
    public class OrderTableBasicDto
    {
        public virtual long ID { get; set; }
        public virtual long OrderID { get; set; }
        public virtual LanguageTableDto Table { get; set; }
    }
}
