using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.UserAccess
{
    public class UserAccessManager
    {
        private static readonly List<UserAccess> userAccesses = new List<UserAccess>();

        public static List<UserAccess> List
        {
            get { return userAccesses; }
        }

        public static void Add(UserAccess userAccess)
        {
            if (userAccesses.All(x => x.SessionId != userAccess.SessionId))
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

        public static void Remove(string sessionId)
        {
            if (userAccesses.Any(x => x.SessionId == sessionId))
                userAccesses.RemoveAll(x => x.SessionId == sessionId);
        }

        public static void RemoveCurrentUser()
        {
            Remove(SmsSystem.SessionId);
        }

        public static void UpdateLastAccess(string sessionId)
        {
            if (userAccesses.Any(x => x.SessionId == sessionId))
                userAccesses.First(x => x.SessionId == sessionId).LastAccess = DateTime.Now;
        }

        public static void UpdateCurrentUserLastAccess()
        {
            UpdateLastAccess(SmsSystem.SessionId);
        }

        public static void UpdateBranchId(string sessionId, long branchId)
        {
            if (userAccesses.Any(x => x.SessionId == sessionId))
                userAccesses.First(x => x.SessionId == sessionId).CurrentBranchId = branchId;
        }

        public static void UpdateCurrentUserBranchId(long branchId)
        {
            UpdateBranchId(SmsSystem.SessionId, branchId);
        }
    }
}
