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

			if (statuscode == 500)
			{
				return View("Error500");
			}
			else if (statuscode == 404)
			{
				return View("Error404");
			}
			return View(statuscode);
		}

		[Route("Error404")]
		public IActionResult Error404()
		{

			return View();

		}
		[Route("Error500")]
		public IActionResult Error500()
		{

			return View();

		}
	}
}
