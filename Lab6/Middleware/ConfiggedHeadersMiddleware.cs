using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Lab6.Middleware
{
    public class ConfiggedHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfiggedHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IOptions<HeaderOptions> headerOptions)
        {   
            //The OnStarting callback executes when the response is first being created
            //Attempting to modify the headers without this may result in errors depending on the order of middleware attempting to write data to the response
            context.Response.OnStarting(state => {
                context.Response.StatusCode = 200; 
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("LabNumber", headerOptions.Value.LabNumber);
                httpContext.Response.Headers.Add("AuthoredBy", headerOptions.Value.AuthoredBy);
                return Task.CompletedTask;
            }, context);

            //Call the next route in the pipeline
            await _next(context);
        }
    }
}