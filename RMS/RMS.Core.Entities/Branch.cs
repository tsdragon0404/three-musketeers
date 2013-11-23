using System;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class Branch : Entity
    {
        [DataField("BranchID")]
        public virtual Guid BranchID { get; set; }

        [DataField("BranchName")]
        public virtual string BranchName { get; set; }

        [DataField("VNName")]
        public virtual string VNName { get; set; }

        [DataField("ENName")]
        public virtual string ENName { get; set; }

        [DataField("Enable")]
        public virtual bool Enable { get; set; }

        [DataField("SEQ")]
        public virtual int SEQ { get; set; }
    }
}
