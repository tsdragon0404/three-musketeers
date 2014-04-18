using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class AreaMap : BaseMap<Area>
    {
        public AreaMap()
        {
            Table("Area");
            Map(x => x.VNName);
            Map(x => x.ENName);
            Map(x => x.BranchID);
            Map(x => x.Enable);
            Map(x => x.SEQ);
            Map(x => x.CreatedDate);
            Map(x => x.CreatedUser);
            Map(x => x.ModifiedDate);
            Map(x => x.ModifiedUser);
        }
    }
}