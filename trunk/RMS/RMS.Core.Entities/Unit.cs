using System;
using TM.Data;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class Unit : Entity
    {
        [DataField("UnitID")]
        public virtual Int16 UnitID { get; set; }

        [DataField("UnitName")]
        public virtual string UnitName { get; set; }

        [DataField("VNName")]
        public virtual string VNName { get; set; }

        [DataField("ENName")]
        public virtual string ENName { get; set; }

        [DataField("Enable")]
        public virtual bool Enable { get; set; }

        [DataField("SEQ")]
        public virtual Int32 SEQ { get; set; }
    }
}
