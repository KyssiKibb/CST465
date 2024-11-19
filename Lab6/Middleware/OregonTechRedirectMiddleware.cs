using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

namespace Lab6.Middleware
{
	public class OregonTechRedirectMiddleware
	{
		private readonly RequestDelegate _next;

		public OregonTechRedirectMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IOptions<HeaderOptions> headerOptions)
		{
			//Status code should be set at the beginning of the response processing
			//Attempting to modify the status code elsewhere may result in errors
			context.Response.OnStarting(state => {
				var context = (HttpContext)state;
				context.Response.StatusCode = 302;
				context.Response.Headers.Add("Location", headerOptions.Value.Location);
				context.Response.Redirect(headerOptions.Value.Location);
				return Task.CompletedTask;
			}, context);

			await context.Response.StartAsync();

			//Notice that I'm not calling the following here causing the pipeline 
			//to "short-circuit", or in other words, not call any middleware registered after this

			//await _next(context); 
		}
	}
}
