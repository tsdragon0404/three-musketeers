namespace SMS.Data.Dtos
{
    public class SearchProductPopupDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual decimal Price { get; set; }
    }
}
