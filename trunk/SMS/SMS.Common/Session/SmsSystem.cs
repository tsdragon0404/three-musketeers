﻿using System.Collections.Generic;
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
    }
}