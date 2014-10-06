using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class SystemInformationMap : BaseMap<SystemInformation>
    {
        public SystemInformationMap()
        {
            Table("SystemInformation");
            Map(x => x.Name);
            Map(x => x.Value);
            Map(x => x.Type).CustomType<SystemInformationType>();
        }
    }
}
