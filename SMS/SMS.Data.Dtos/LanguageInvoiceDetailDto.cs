namespace SMS.Data.Dtos
{
    public class LanguageInvoiceDetailDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual string UnitName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Comment { get; set; }
    }
}
