using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace Assignment3.Controllers
{
	[Route("Blog")]
	public class BlogController : Controller
	{
		private readonly IConfiguration _Config;

		IDataEntityRepository<BlogPost> post;

		BlogController(IConfiguration configuration)
		{
			_Config = configuration;
			post = new BlogDBRepository(_Config);
			
		}
		[Route("Blog/Index")]
		public IActionResult Index()
		{
			List<BlogPost> posts = post.GetList();
			return View(posts);
		}
		[Route("Blog/Add")]
		public IActionResult Add()
		{
			BlogPostModel model = new BlogPostModel();
			return View(model);
		}
		[HttpPost]
		public IActionResult Add(BlogPostModel blogModel)
		{
			if (ModelState.IsValid)
			{
				BlogPost blog = new()
				{
					ID = blogModel.ID,
					Author = blogModel.Author,
					Title = blogModel.Title,
					Content = blogModel.Content,
					Timestamp = DateTime.Now,
				};
				post.Save(blog);
				return RedirectToAction("Index");
			}
			return View(blogModel);
		}

		public IActionResult Edit(int id)
		{
			BlogPost blog = post.Get(id);
			BlogPostModel model = new()
			{
				ID=blog.ID,
				Author = blog.Author,
				Title = blog.Title,
				Content = blog.Content,
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(BlogPostModel blogModel)
		{
			if (ModelState.IsValid)
			{
				BlogPost blog = new()
				{
					ID = blogModel.ID,
					Author = blogModel.Author,
					Title = blogModel.Title,
					Content = blogModel.Content,
					Timestamp = DateTime.Now,
				};
				post.Save(blog);
				return RedirectToAction("Index");
			}
			return View(blogModel);
		}

	}
}
