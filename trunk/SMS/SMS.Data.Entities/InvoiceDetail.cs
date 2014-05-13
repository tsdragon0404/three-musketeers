using Core.Data;
using SMS.Common.Constant;

namespace SMS.Data.Entities
{
    public class InvoiceDetail : Entity
    {
        public virtual InvoiceTable InvoiceTable { get; set; }

        public virtual string ProductCode { get; set; }

        public virtual string ProductVNName { get; set; }

        public virtual string ProductENName { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual string UnitVNName { get; set; }

        public virtual string UnitENName { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string Comment { get; set; }
    }
}