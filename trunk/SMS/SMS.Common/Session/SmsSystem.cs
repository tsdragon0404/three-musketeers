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
    }
}