using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class ProductPriceHistory : Entity
    {
        public virtual long ProductID { get; set; }

        public virtual decimal OldPrice { get; set; }

        public virtual decimal NewPrice { get; set; }

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }
    }
}
