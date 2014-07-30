using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class ErrorMessage : Entity, IBranchEntity
    {
        public virtual long MessageID { get; set; }

        public virtual string VNMessage { get; set; }

        public virtual string ENMessage { get; set; }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion
    }
}