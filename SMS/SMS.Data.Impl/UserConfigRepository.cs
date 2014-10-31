using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class UserConfigRepository : BaseRepository<UserConfig>, IUserConfigRepository
    {
        public override Func<UserConfig, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.BranchID == y;
            }
        }

        //TODO: this will be merged with the SaveUserProfile after refactor theme into Enum
        public void SaveThemeAndPageSize(long userID, long branchID, string theme, int pageSize)
        {
            var userConfig = FindOne(x => x.UserID == userID && x.BranchID == branchID);

            if (userConfig == null)
            {
                Add(new UserConfig
                        {
                            BranchID = branchID,
                            UserID = userID,
                            Theme = theme,
                            PageSize = pageSize
                        });
            }
            else
            {
                userConfig.Theme = theme;
                userConfig.PageSize = pageSize;
                Update(userConfig);
            }
        }

        public UserConfig SaveUserProfile(long userID, long branchID, long? defaultAreaID = null, decimal? listTableHeight = null, bool? IsSuspended = null)
        {
            var userConfig = FindOne(x => x.UserID == userID && x.BranchID == branchID);

            if (userConfig == null)
            {
                var entity = new UserConfig
                                 {
                                     BranchID = branchID,
                                     UserID = userID
                                 };
                if (defaultAreaID.HasValue)
                    entity.DefaultAreaID = defaultAreaID.Value;
                if (listTableHeight.HasValue)
                    entity.ListTableHeight = listTableHeight.Value;
                if (IsSuspended.HasValue)
                    entity.IsSuspended = IsSuspended.Value;
                
                Add(entity);
            }
            else
            {
                if(defaultAreaID.HasValue)
                    userConfig.DefaultAreaID = defaultAreaID.Value;
                if (listTableHeight.HasValue)
                    userConfig.ListTableHeight = listTableHeight.Value;
                if (IsSuspended.HasValue)
                    userConfig.IsSuspended = IsSuspended.Value;

                Update(userConfig);
            }

            return userConfig;
        }
    }
}
