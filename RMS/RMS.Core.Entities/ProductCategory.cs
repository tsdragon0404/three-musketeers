using System;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class ProductCategory : Entity
    {
        [DataField("ProductCategoryID")]
        public virtual Int32 ProductCategoryID { get; set; }

        [DataField("Name")]
        public virtual string Name { get; set; }

        [DataField("VNName")]
        public virtual string VNName { get; set; }

        [DataField("ENName")]
        public virtual string ENName { get; set; }

        [DataField("Description")]
        public virtual string Description { get; set; }

        [DataField("VNDescription")]
        public virtual string VNDescription { get; set; }

        [DataField("ENDescription")]
        public virtual string ENDescription { get; set; }

        [DataField("BranchID")]
        public virtual Guid BranchID { get; set; }

        [DataField("Enable")]
        public virtual bool Enable { get; set; }

        [DataField("SEQ")]
        public virtual Int32 SEQ { get; set; }
    }
}
