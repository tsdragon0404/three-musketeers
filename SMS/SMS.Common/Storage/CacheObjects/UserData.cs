using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Constant;
using SMS.Common.Enums;

namespace SMS.Common.Storage.CacheObjects
{
    public class UserData : ICacheData
    {
        public Guid TokenID { get; set; }

        public string SessionID { get; set; }

        public long UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool UseSystemConfig { get; set; }

        public long CurrentBranchId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime LastAccess { get; set; }

        public IList<BranchName> AllowBranches { get; set; }
        public List<long> AllowPageIDs { get; set; }

        public int PageSize { get; set; }
        public long DefaultAreaID { get; set; }
        public string Theme { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public decimal ListTableHeight { get; set; }

        public bool IsSessionExpired
        {
            get { return LastAccess.AddMinutes(ConstConfig.SessionTimeoutDuration) < DateTime.Now; }
        }

        #region Implementation of ICacheData

        public object Key { get { return TokenID; } }
        public bool IsCurrent { get { return CommonObjects.TokenID == TokenID; } }

        #endregion
    }

    public class UserDataCollection : CacheDataCollection<UserData, Guid>
    {
        public void Add(string sessionID, long userID, string userName, string firstName, string lastName, string ipAddress, string userAgent,
                        long selectedBranchID, bool isSystemAdmin, bool useSystemConfig, long defaultAreaID,
                        decimal listTableHeight, int pageSize, string theme, IList<BranchName> allowBranches, List<long> allowPageIDs)
        {
            var userAccess = new UserData
            {
                TokenID = Guid.NewGuid(),
                SessionID = sessionID,
                UserID = userID,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                IpAddress = ipAddress,
                UserAgent = userAgent,
                CurrentBranchId = selectedBranchID,
                IsSystemAdmin = isSystemAdmin,
                UseSystemConfig = useSystemConfig,
                DefaultAreaID = defaultAreaID,
                ListTableHeight = listTableHeight,
                PageSize = pageSize,
                Theme = theme,
                AllowBranches = allowBranches,
                AllowPageIDs = allowPageIDs,
                LastAccess = DateTime.Now,
                LoginDateTime = DateTime.Now,
            };

            if (this.All(x => x.SessionID != sessionID))
                Add(userAccess);
        }

        public UserData Get(string sessionId)
        {
            return this.FirstOrDefault(x => x.SessionID == sessionId);
        }

        public bool AuthorizeSession()
        {
            RemoveExpiredSessions();
            return Contains(CommonObjects.TokenID);
        }

        public new void Add(UserData userData)
        {
            RemoveExpiredSessions();
            if (!Contains(userData.TokenID))
                base.Add(userData);
        }

        public new bool Remove(Guid tokenID)
        {
            if (!Contains(tokenID))
                return false;

            return RemoveAll(x => x.TokenID == tokenID) > 0;
        }

        public void RemoveCurrentUser()
        {
            RemoveExpiredSessions();
            Remove(CommonObjects.TokenID);
        }

        public void UpdateLastAccess(Guid tokenID)
        {
            if (Contains(tokenID))
                this.First(x => x.TokenID == tokenID).LastAccess = DateTime.Now;
        }

        public void UpdateCurrentUserLastAccess()
        {
            UpdateLastAccess(CommonObjects.TokenID);
        }

        public void UpdateBranchId(Guid tokenID, long branchId)
        {
            if (Contains(tokenID))
                this.First(x => x.TokenID == tokenID).CurrentBranchId = branchId;
        }

        public void UpdateCurrentUserBranchId(long branchId)
        {
            UpdateBranchId(CommonObjects.TokenID, branchId);
        }

        private void RemoveExpiredSessions()
        {
            RemoveAll(x => x.IsSessionExpired);
        }
    }

    public class BranchName
    {
        public long ID { get; set; }
        private string VNName { get; set; }
        private string ENName { get; set; }
        public string Name
        {
            get { return CommonObjects.Language == Language.Vietnamese ? VNName : ENName; }
        }

        public BranchName(long id, string vnName, string enName)
        {
            ID = id;
            VNName = vnName;
            ENName = enName;
        }
    }
}
