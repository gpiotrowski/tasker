using Microsoft.AspNetCore.Builder;

namespace Tasker.Infrastructure.Gateway
{
    public static class GatewayRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseGatewayRouting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GatewayRedirectMiddleware>();
        }
    }
}