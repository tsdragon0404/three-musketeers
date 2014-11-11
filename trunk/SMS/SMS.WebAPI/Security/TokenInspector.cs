using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SMS.WebAPI.Security
{
    public class TokenInspector : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            const string TOKEN_NAME = "SMS-Token";

            if (request.Headers.Contains(TOKEN_NAME))
            {
                var encryptedToken = request.Headers.GetValues(TOKEN_NAME).First();
                try
                {
                    var token = Token.Decrypt(encryptedToken);
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

        private IPAddress GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
                return IPAddress.Parse(((HttpContextBase) request.Properties["MS_HttpContext"]).Request.UserHostAddress);
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                return IPAddress.Parse(((RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name]).Address);
            throw new Exception("Client IP Address Not Found in HttpRequest");
        }
    }
}