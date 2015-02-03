using System;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("AREA")]
    [PrimaryKey("ID")]
    public class Area
    {
        public long ID { get; set; }
        public long BranchID { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual bool Enable { get; set; }
        public virtual int SEQ { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}