using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace Lab6.Middleware
{
    public class RequestHijackedMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestHijackedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {   
            //Status code should be set at the beginning of the response processing
            //Attempting to modify the status code elsewhere may result in errors
            context.Response.OnStarting(state => {
                var context = (HttpContext)state;
                context.Response.StatusCode = 200; //200 Status Code is the default when a request is successful
                return Task.CompletedTask;
            }, context);
            
            await context.Response.WriteAsync("You've been hijacked!");

            //Notice that I'm not calling the following here causing the pipeline 
            //to "short-circuit", or in other words, not call any middleware registered after this

            //await _next(context); 
        }
    }
}