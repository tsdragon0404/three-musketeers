using System;
using System.Web;
using System.Web.Http;
using SMS.Common.Constant;

namespace SMS.WebAPI.Base
{
    public abstract class BaseController : ApiController
    {
        protected Guid TokenID
        {
            get { return Guid.Parse(HttpContext.Current.Request.Headers.Get(ConstKey.Token)); }
        }
    }
}