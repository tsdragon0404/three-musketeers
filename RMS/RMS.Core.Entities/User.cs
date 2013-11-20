using System;
using TM.Data;
using TM.Data.BaseClasses;
using TM.Data.Mapping;

namespace RMS.Core.Entities
{
    public class User : Entity
    {
        [DataField("UserID")]
        public virtual Guid UserID { get; set; }

        [DataField("UserCode")]
        public virtual string UserCode { get; set; }

        [DataField("UserLogin")]
        public virtual string UserLogin { get; set; }

        [DataField("UserPassword")]
        public virtual string UserPassword { get; set; }

        [DataField("FirstName")]
        public virtual string FirstName { get; set; }

        [DataField("LastName")]
        public virtual string LastName { get; set; }

        [DataField("CellPhone")]
        public virtual string CellPhone { get; set; }

        [DataField("Enable")]
        public virtual bool Enable { get; set; }

        [DataField("SEQ")]
        public virtual int SEQ { get; set; }
    }
}