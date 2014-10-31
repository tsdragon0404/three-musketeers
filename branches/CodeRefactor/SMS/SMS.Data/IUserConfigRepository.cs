using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IUserConfigRepository : IBaseRepository<UserConfig>
    {
        UserConfig SaveUserProfile(long userID, long branchID, long? defaultAreaID = null, decimal? listTableHeight = null, bool? IsSuspended = null);
        void SaveThemeAndPageSize(long userID, long branchID, string theme, int pageSize);
    }
}