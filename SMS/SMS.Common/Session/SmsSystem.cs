using System;
using System.Collections.Generic;
using System.Globalization;
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
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstKey.Session_UserContext] != null)
                    return HttpContext.Current.Session[ConstKey.Session_UserContext] as UserContext;

                return new UserContext();
            }
            set
            {
                HttpContext.Current.Session[ConstKey.Session_UserContext] = value;
            }
        }

        public static ClientInfo ClientInfo
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstKey.Session_ClientInfo] != null)
                    return HttpContext.Current.Session[ConstKey.Session_ClientInfo] as ClientInfo;

                return new ClientInfo();
            }
            set
            {
                HttpContext.Current.Session[ConstKey.Session_ClientInfo] = value;
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
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstKey.Session_AllowRoles] != null)
                    return HttpContext.Current.Session[ConstKey.Session_AllowRoles] as List<long>;

                return new List<long>();
            }
            set
            {
                HttpContext.Current.Session[ConstKey.Session_AllowRoles] = value;
            }
        }

        public static long SelectedBranchID
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session[ConstKey.Session_SelectedBranchID] != null)
                    return (long)HttpContext.Current.Session[ConstKey.Session_SelectedBranchID];

                return 0;
            }
            set
            {
                HttpContext.Current.Session[ConstKey.Session_SelectedBranchID] = value;
            }
        }

        public static Language Language
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language] != null 
                    && HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language].Value != null)
                {
                    int value;
                    int.TryParse(HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language].Value, out value);

                    if(value != (int)Language.Vietnamese && value != (int)Language.English)
                        return Language.Vietnamese;
                    if (value != 0)
                        return (Language)value;
                }

                return Language.Vietnamese;
            }
            set
            {
                var cookie = new HttpCookie(ConstKey.Cookie_Language)
                {
                    Expires = DateTime.Now.AddDays(365),
                    Value = ((int)value).ToString(CultureInfo.InvariantCulture)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static long PreviousSelectedBranch
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ConstKey.Cookie_PreviousSelectedBranch] != null
                    && HttpContext.Current.Request.Cookies[ConstKey.Cookie_PreviousSelectedBranch].Value != null)
                {
                    long value;
                    long.TryParse(HttpContext.Current.Request.Cookies[ConstKey.Cookie_PreviousSelectedBranch].Value, out value);

                    return value;
                }

                return 0;
            }
            set
            {
                var cookie = new HttpCookie(ConstKey.Cookie_PreviousSelectedBranch)
                {
                    Expires = DateTime.Now.AddDays(365),
                    Value = value.ToString(CultureInfo.InvariantCulture)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}