using System;

namespace SMS.Data.Dtos
{
    public class ProductPriceHistoryDto
    {
        public virtual long ID { get; set; }
        public virtual long ProductID { get; set; }
        public virtual decimal OldPrice { get; set; }
        public virtual decimal NewPrice { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
    }
}
