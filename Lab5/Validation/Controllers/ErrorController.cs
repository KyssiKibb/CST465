using Microsoft.AspNetCore.Mvc;


namespace Validation
{
	[Route("/Error")]
	public class ErrorController : Controller
	{
		public ErrorController() { }
		[Route("")]
		public IActionResult Index() 
		{ 
			int statuscode = HttpContext.Response.StatusCode;
			return View(statuscode);
		}
	}
}
