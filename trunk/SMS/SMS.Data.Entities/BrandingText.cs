using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("BRANDINGTEXT")]
    [PrimaryKey("ID")]
    public class BrandingText
    {
        public long ID { get; set; }
        public string Key { get; set; }
        public string VNValue { get; set; }
        public string ENValue { get; set; }
        public long BranchID { get; set; }
    }
}