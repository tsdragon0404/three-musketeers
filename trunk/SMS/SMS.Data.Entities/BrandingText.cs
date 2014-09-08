using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class BrandingText : Entity, IBranchEntity
    {
        public virtual string Key { get; set; }

        public virtual string VNValue { get; set; }

        public virtual string ENValue { get; set; }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion
    }
}