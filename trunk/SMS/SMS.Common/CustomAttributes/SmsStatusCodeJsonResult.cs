using System.Net;
using System.Web.Mvc;

namespace SMS.Common.CustomAttributes
{
    public class SmsStatusCodeJsonResult : JsonResult
    {
        private HttpStatusCode StatusCode { get; set; }
        private string ErrorDescription { get; set; }

        public SmsStatusCodeJsonResult(HttpStatusCode statusCode, string errorDescription)
        {
            StatusCode = statusCode;
            ErrorDescription = errorDescription;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = (int)StatusCode;
            context.HttpContext.Response.Write(ErrorDescription);
            context.HttpContext.Response.End();
        } 
    }
}