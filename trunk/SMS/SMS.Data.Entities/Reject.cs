using System;

namespace SMS.Data.Entities
{
    public class Reject : Entity
    {
        public virtual long BranchID { get; set; }

        public virtual string ProductCode { get; set; }

        public virtual string ProductVNName { get; set; }

        public virtual string ProductENName { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual string UnitVNName { get; set; }

        public virtual string UnitENName { get; set; }

        public virtual string OrderComment { get; set; }

        public virtual string KitchenComment { get; set; }
        
        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }
    }
}