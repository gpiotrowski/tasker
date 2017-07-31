using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tasker.Infrastructure.Gateway
{
    public class GatewayRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public GatewayRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //TODO: Move this key to config file
            var gatewayHeaderKey = "X-Gateway-Target";

            if (context.Request.Headers.ContainsKey(gatewayHeaderKey))
            {
                var targetServer = context.Request.Headers[gatewayHeaderKey].SingleOrDefault();

                var targetHost = String.Empty;

                //TODO: Move this mapping to config file
                switch (targetServer.ToLower())
                {
                    case "projects":
                        targetHost = "localhost:60332";
                        break;
                    case "users":
                        targetHost = "localhost:60348";
                        break;
                }

                if (targetHost != String.Empty)
                {
                    var protocol = context.Request.IsHttps ? "https" : "http";
                    //TODO: context.Response.Redirect work only with GET request - find other solution for POST request
                    context.Response.Redirect($"{protocol}://{targetHost}{context.Request.Path}{context.Request.QueryString}");
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}