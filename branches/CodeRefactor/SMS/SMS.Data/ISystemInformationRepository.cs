using SMS.Data.Entities;

namespace SMS.Data
{
    public interface ISystemInformationRepository : IBaseRepository<SystemInformation>
    {
        void UpdateSystemConfig(SystemInformation[] systemInformations);
    }
}