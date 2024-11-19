using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace Lab6
{
    public class HomeController : Controller
    {
        private readonly HeaderOptions _HeaderOptions;
        public HomeController(IOptions<HeaderOptions> headerOptions)
        {
            _HeaderOptions = headerOptions.Value;
        }
        public IActionResult Index()
        {
            ViewBag.Options = _HeaderOptions;
            return View();
        }
    }
}