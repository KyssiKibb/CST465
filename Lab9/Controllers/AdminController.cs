using Lab9.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[Authorize]
[Route("Admin")]
public class AdminController : Controller
{
	private readonly ILogger<AdminController> _logger;

	public AdminController(ILogger<AdminController> logger)
	{
		_logger = logger;
	}
	[Route("Index")]
	[Route("")]
	public IActionResult Index()
	{
		return View();
	}
	[Route("Privacy")]
	public IActionResult Privacy()
	{
		return View();
	}
	[Route("Error")]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}