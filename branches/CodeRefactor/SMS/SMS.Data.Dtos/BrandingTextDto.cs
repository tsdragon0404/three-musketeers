namespace SMS.Data.Dtos
{
    public class BrandingTextDto
    {
        public virtual long ID { get; set; }
        public virtual string Key { get; set; }
        public virtual string VNValue { get; set; }
        public virtual string ENValue { get; set; }
        public virtual long BranchID { get; set; }
    }
}
