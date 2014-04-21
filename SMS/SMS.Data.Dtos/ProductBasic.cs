using System;

namespace SMS.Data.Dtos
{
    public class ProductBasicDto
    {
        public virtual long Id { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual long UnitID { get; set; }
        public virtual decimal Price { get; set; }
    }
}
