using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.Storage.UserAccess
{
    public class UserAccessManager
    {
        private static readonly List<UserAccess> userAccesses = new List<UserAccess>();

        public static List<UserAccess> List
        {
            get
            {
                RefreshList();
                return userAccesses;
            }
        }

        public static bool AuthorizeCurrentUser()
        {
            return Contains(SmsSystem.SessionId);
        }

        public static bool Contains(string sessionId)
        {
            return userAccesses.Any(x => x.SessionId == sessionId);
        }

        public static void Add(UserAccess userAccess)
        {
            if (!Contains(userAccess.SessionId))
                userAccesses.Add(userAccess);
        }

        public static void AddCurrentUser()
        {
            var userAccess = new UserAccess
                             {
                                 ClientInfo = SmsSystem.ClientInfo,
                                 SessionId = SmsSystem.SessionId,
                                 UserName = SmsSystem.UserContext.UserName,
                                 CurrentBranchId = SmsSystem.SelectedBranchID,
                                 LoginDateTime = DateTime.Now,
                                 LastAccess = DateTime.Now
                             };
            Add(userAccess);
        }

        public static bool Remove(string sessionId)
        {
            if (sessionId == SmsSystem.SessionId || !Contains(sessionId))
                return false;

            userAccesses.RemoveAll(x => x.SessionId == sessionId);
            return true;
        }

        public static void RemoveCurrentUser()
        {
            Remove(SmsSystem.SessionId);
        }

        public static void UpdateLastAccess(string sessionId)
        {
            if (Contains(sessionId))
                userAccesses.First(x => x.SessionId == sessionId).LastAccess = DateTime.Now;
        }

        public static void UpdateCurrentUserLastAccess()
        {
            UpdateLastAccess(SmsSystem.SessionId);
        }

        public static void UpdateBranchId(string sessionId, long branchId)
        {
            if (Contains(sessionId))
                userAccesses.First(x => x.SessionId == sessionId).CurrentBranchId = branchId;
        }

        public static void UpdateCurrentUserBranchId(long branchId)
        {
            UpdateBranchId(SmsSystem.SessionId, branchId);
        }

        private static void RefreshList()
        {
            userAccesses.RemoveAll(x => x.LastAccess.AddMinutes(ConstConfig.SessionTimeoutDuration) < DateTime.Now);
        }
    }
}
