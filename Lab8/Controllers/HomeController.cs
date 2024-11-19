using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using Lab8.Repositories;

namespace Lab8.Controllers;
[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IImageRepository _ImageRepo;

    public HomeController(IImageRepository imageRepo)
    {
        _ImageRepo = imageRepo;
    }
    [Route("")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        return View();
    }
    
    
}
