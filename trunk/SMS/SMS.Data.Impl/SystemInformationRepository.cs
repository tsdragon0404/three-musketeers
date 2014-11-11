using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class SystemInformationRepository : BaseRepository<SystemInformation>, ISystemInformationRepository
    {
        public void UpdateSystemConfig(SystemInformation[] systemInformations)
        {
            foreach (var systemInformation in systemInformations)
            {
                var information = systemInformation;
                var record = FindOne(x => x.Name == information.Name && x.Type == SystemInformationType.Config);
                if(record != null)
                {
                    record.Value = systemInformation.Value;
                    Update(record);
                }
            }
        }
    }
}
