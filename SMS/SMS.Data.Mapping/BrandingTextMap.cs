using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class BrandingTextMap : BaseMap<BrandingText>
    {
        public BrandingTextMap()
        {
            Table("BrandingText");
            Map(x => x.Key).Column("[Key]").ReadOnly();
            Map(x => x.VNValue).ReadOnly();
            Map(x => x.ENValue).ReadOnly();
            Map(x => x.BranchID).ReadOnly();
        }
    }
}