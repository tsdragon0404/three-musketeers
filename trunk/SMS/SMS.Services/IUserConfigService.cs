using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUserConfigService : IBaseService<UserConfigDto, long>
    {
        UserConfigDto GetUserConfig(long userID, long branchID);
    }
}