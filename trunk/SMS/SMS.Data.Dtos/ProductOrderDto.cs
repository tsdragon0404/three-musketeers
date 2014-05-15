namespace SMS.Data.Dtos
{
    public class ProductOrderDto
    {
        public virtual long ID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual long UnitID { get; set; }
        public virtual UnitDto Unit { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal Quantity { get; set; }
    }
}
