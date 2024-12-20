﻿using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace Assignment3.Controllers
{
	[Route("Blog")]
	public class BlogController : Controller
	{
		private readonly IConfiguration _Config;

		private readonly IDataEntityRepository<BlogPost> post;

		public BlogController(IConfiguration configuration, IDataEntityRepository<BlogPost> repo)
		{
			_Config = configuration;
			post = repo;
			
		}
		[Route("Index")]
		[Route("")]
		public IActionResult Index()
		{
			List<BlogPost> posts = post.GetList();
			return View(posts);
		}
		[Route("Add")]
		[HttpGet]
		public IActionResult Add()
		{
			BlogPostModel model = new BlogPostModel();
			return View(model);
		}
		[Route("Add")]
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
		[Route("Edit/{id}")]
		[HttpGet]
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
		[Route("Edit/{ID}")]
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
