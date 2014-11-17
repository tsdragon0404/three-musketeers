using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SMS.Common.Constant;
using SMS.Common.Storage;

namespace SMS.WebAPI.Security
{
    public class TokenInspector : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains(ConstKey.Token))
            {
                var encryptedToken = request.Headers.GetValues(ConstKey.Token).First();
                try
                {
                    var token = Token.Decrypt(encryptedToken);
                    //if (!SmsCache.UserData.Contains(token.ID))
                    //    throw new Exception();

                    //validate token in UserAccess

                    //bool isExpire = false;
                    //if(isExpire)
                    //{
                    //    var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token expired.");
                    //    return Task.FromResult(reply);
                    //}

                    //bool isValidUserId = true;
                    //bool requestIPMatchesTokenIP = token.IP.Equals(GetClientIpAddress(request));

                    //if (!isValidUserId || !requestIPMatchesTokenIP)
                    //{
                    //    var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid identity or client machine.");
                    //    return Task.FromResult(reply);
                    //}
                }
                catch (Exception)
                {
                    var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                    return Task.FromResult(reply);
                }
            }
            else
            {
                var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Request is missing authorization token.");
                return Task.FromResult(reply);
            }

            return base.SendAsync(request, cancellationToken);
        }

        //private IPAddress GetClientIpAddress(HttpRequestMessage request)
        //{
        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //        return IPAddress.Parse(((HttpContextBase) request.Properties["MS_HttpContext"]).Request.UserHostAddress);
        //    if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
        //        return IPAddress.Parse(((RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name]).Address);
        //    throw new Exception("Client IP Address Not Found in HttpRequest");
        //}
    }
}