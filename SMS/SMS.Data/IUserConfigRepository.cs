using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IUserConfigRepository : IBaseRepository<UserConfig>
    {
        UserConfig SaveCashierInfo(long defaultAreaID, decimal listTableHeight);
    }
}