using System;
using System.Globalization;
using System.Web;
using SMS.Common.Constant;
using SMS.Common.Enums;
using SMS.Common.Storage;

namespace SMS.Common
{
    public static class CommonObjects
    {
        public static string SessionId
        {
            get { return HttpContext.Current.Session != null ? HttpContext.Current.Session.SessionID : string.Empty; }
        }

        public static Guid TokenID
        {
            get
            {
                if (SessionId != string.Empty)
                {
                    var userData = SmsCache.UserAccesses.Get(SessionId);
                    return userData != null ? userData.TokenID : Guid.NewGuid();
                }

                var tokenStr = HttpContext.Current.Request.Headers.Get(ConstKey.Token_Guid);
                Guid tokenID;
                if (tokenStr == null || !Guid.TryParse(tokenStr, out tokenID))
                    throw new Exception("Invalid token!");

                return tokenID;
            }
        }

        #region Cookies
        
        public static Language Language
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language] != null
                    && HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language].Value != null)
                {
                    int value;
                    int.TryParse(HttpContext.Current.Request.Cookies[ConstKey.Cookie_Language].Value, out value);

                    if (value != (int)Language.Vietnamese && value != (int)Language.English)
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

        #endregion
    }
}