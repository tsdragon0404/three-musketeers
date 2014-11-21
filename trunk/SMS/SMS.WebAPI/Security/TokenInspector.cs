using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SMS.Common.Constant;
using SMS.Common.Storage;

namespace SMS.WebAPI.Security
{
    public class TokenInspector : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Token token;
            if (request.Headers.Contains(ConstKey.Token))
            {
                var encryptedToken = request.Headers.GetValues(ConstKey.Token).First();
                try
                {
                    token = Token.Decrypt(encryptedToken);

                    if (!SmsCache.UserAccesses.Contains(token.ID))
                        throw new Exception();

                    var authorizedUser = SmsCache.UserAccesses.Get(token.ID);
                    if (authorizedUser.IsSessionExpired)
                    {
                        var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Token expired.");
                        return Task.FromResult(reply);
                    }

                    if (!authorizedUser.IpAddress.Equals(GetClientIpAddress(request)))
                    {
                        var reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid client machine.");
                        return Task.FromResult(reply);
                    }
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

            request.Headers.Add(ConstKey.Token_Guid, token.ID.ToString());
            return base.SendAsync(request, cancellationToken);
        }

        private string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
                return ((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                return ((RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name]).Address;
            throw new Exception("Client IP Address Not Found in HttpRequest");
        }
    }
}