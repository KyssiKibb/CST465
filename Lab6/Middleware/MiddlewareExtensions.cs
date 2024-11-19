using Microsoft.AspNetCore.Builder;

namespace Lab6.Middleware
{
public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestHacked(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHijackedMiddleware>();
        }
        public static IApplicationBuilder UseConfiggedHeaders(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConfiggedHeadersMiddleware>();
        }
		public static IApplicationBuilder UseOregonTechRedirect(
			this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<OregonTechRedirectMiddleware>();
		}
	}
}