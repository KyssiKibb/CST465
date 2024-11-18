using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
	public class BlogController : Controller
	{
		private readonly IConfiguration _Config;

		IDataEntityRepository<BlogPost> post;

		BlogController(IConfiguration configuration)
		{
			_Config = configuration;
			post = new BlogDBRepository(_Config);
			
		}

		public IActionResult Index()
		{
			return View(post);
		}

		public IActionResult Add()
		{
			return View(post);
		}

		public IActionResult Add(BlogPostModel blogModel)
		{
			return View(post);
		}

		public IActionResult Edit(int id)
		{
			return View(post);
		}

		public IActionResult Edit(BlogPostModel blogModel)
		{
			return View(post);
		}

	}
}
