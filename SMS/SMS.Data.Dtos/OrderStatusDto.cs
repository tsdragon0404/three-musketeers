namespace SMS.Data.Dtos
{
    public class OrderStatusDto
    {
        public virtual long ID { get; set; }
        public string VNName { get; set; }
        public string ENName { get; set; }
    }

    public class LanguageOrderStatusDto
    {
        public virtual long ID { get; set; }
        public virtual string Name { get; set; }
    }
}
