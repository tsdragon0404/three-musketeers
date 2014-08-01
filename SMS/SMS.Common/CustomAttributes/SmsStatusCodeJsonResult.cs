using System.Net;
using System.Web.Mvc;

namespace SMS.Common.CustomAttributes
{
    public class SmsStatusCodeJsonResult : JsonResult
    {
        private HttpStatusCode StatusCode { get; set; }
        private string StatusDescription { get; set; }

        public SmsStatusCodeJsonResult(HttpStatusCode statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = (int)StatusCode;
            context.HttpContext.Response.StatusDescription = StatusDescription;
            context.HttpContext.Response.End();
        } 
    }
}