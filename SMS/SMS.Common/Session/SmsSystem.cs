using System;
using System.Collections.Generic;
using System.Web;
using SMS.Common.Constant;

namespace SMS.Common.Session
{
    public class SmsSystem
    {
        public static UserContext UserContext
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstSessionKey.UserContext] != null)
                {
                    return HttpContext.Current.Session[ConstSessionKey.UserContext] as UserContext;
                }

                return new UserContext();
            }
            set
            {
                HttpContext.Current.Session[ConstSessionKey.UserContext] = value;
            }
        }

        public static ClientInfo ClientInfo
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstSessionKey.ClientInfo] != null)
                {
                    return HttpContext.Current.Session[ConstSessionKey.ClientInfo] as ClientInfo;
                }

                return new ClientInfo();
            }
            set
            {
                HttpContext.Current.Session[ConstSessionKey.ClientInfo] = value;
            }
        }

        private static Dictionary<long, BranchConfig> branchConfigs; 

        public static void SetBranchConfig(long branchID, BranchConfig config)
        {
            if (branchConfigs == null)
                branchConfigs = new Dictionary<long, BranchConfig>();

            if (branchConfigs.ContainsKey(branchID))
                branchConfigs[branchID] = config;
            else
                branchConfigs.Add(branchID, config);
        }

        public static BranchConfig BranchConfig
        {
            get
            {
                if (branchConfigs == null || !branchConfigs.ContainsKey(SelectedBranchID))
                    throw new Exception("Branch config is not set");

                return branchConfigs[SelectedBranchID];
            }
        }

        public static string SessionId
        {
            get { return HttpContext.Current.Session != null ? HttpContext.Current.Session.SessionID : string.Empty; }
        }

        public static List<long> AllowPageIDs
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstSessionKey.AllowRoles] != null)
                {
                    return HttpContext.Current.Session[ConstSessionKey.AllowRoles] as List<long>;
                }

                return new List<long>();
            }
            set
            {
                HttpContext.Current.Session[ConstSessionKey.AllowRoles] = value;
            }
        }

        public static long SelectedBranchID
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstSessionKey.SelectedBranchID] != null)
                {
                    return (long)HttpContext.Current.Session[ConstSessionKey.SelectedBranchID];
                }

                return 0;
            }
            set
            {
                HttpContext.Current.Session[ConstSessionKey.SelectedBranchID] = value;
            }
        }

        public static Language Language
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstSessionKey.Language] != null)
                {
                    return (Language)HttpContext.Current.Session[ConstSessionKey.Language];
                }

                return Language.Vietnamese;
            }
            set
            {
                HttpContext.Current.Session[ConstSessionKey.Language] = value;
            }
        }
    }
}