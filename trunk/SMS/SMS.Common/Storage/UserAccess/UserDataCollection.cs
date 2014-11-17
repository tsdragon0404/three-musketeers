using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Common.Constant;

namespace SMS.Common.Storage.UserAccess
{
    public class UserDataCollection : List<UserData>
    {
        public UserData Current
        {
            get { return Get(Guid.Parse(HttpContext.Current.Request.Headers.Get(ConstKey.Token))); }
        }

        public UserData Get(Guid tokenID)
        {
            return this.FirstOrDefault(x => x.TokenID == tokenID);
        }

        public bool Contains(Guid tokenID)
        {
            return this.Any(x => x.TokenID == tokenID);
        }

        public void Remove(Guid tokenID)
        {
            RemoveAll(x => x.TokenID == tokenID);
        }
    }
}