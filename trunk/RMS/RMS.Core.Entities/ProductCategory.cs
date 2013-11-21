using System;
using TM.Data;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class ProductCategory : Entity
    {
        [DataField("ProductCategoryID")]
        public virtual int ProductCategoryID { get; set; }

        [DataField("VNName")]
        public virtual string VNName { get; set; }

        [DataField("ENName")]
        public virtual string ENName { get; set; }

        [DataField("VNDescription")]
        public virtual string VNDescription { get; set; }

        [DataField("ENDescription")]
        public virtual string ENDescription { get; set; }

        [DataField("BranchID")]
        public virtual Guid BranchID { get; set; }

        [DataField("Enable")]
        public virtual bool Enable { get; set; }

        [DataField("SEQ")]
        public virtual int SEQ { get; set; }
    }
}
