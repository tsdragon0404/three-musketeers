namespace SMS.Data.Dtos
{
    public class ProductForCashierDto
    {
        public virtual long IS { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual int Quantity { get; set; }
        public virtual long UnitID { get; set; }
        public virtual long Price { get; set; }
    }
}
