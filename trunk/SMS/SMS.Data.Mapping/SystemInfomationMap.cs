using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class SystemInfomationMap : BaseMap<SystemInfomation>
    {
        public SystemInfomationMap()
        {
            Table("SystemInfomation");
            Map(x => x.Name);
            Map(x => x.Value);
        }
    }
}
