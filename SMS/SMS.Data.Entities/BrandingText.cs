namespace SMS.Data.Entities
{
    public class BrandingText : Entity
    {
        public virtual string Key { get; set; }

        public virtual string VNValue { get; set; }

        public virtual string ENValue { get; set; }

        public virtual long BranchID { get; set; }
    }
}