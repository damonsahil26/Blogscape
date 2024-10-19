using Blogscape.Models;
using Blogscape.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogscape.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogService _blogService;
        public AdminController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult CreateBlog()
        {
            return View();
        } 
        
        public IActionResult EditBlog(int id)
        {
            var blog = _blogService.GetBlogById(id);

            return View(new Views.Admin.EditBlogModel
            {
                BlogPost = blog
            });
        }

        public IActionResult ViewBlog()
        {
            ViewData["Blogs"] = _blogService.GetBlogs();
            return View();
        }

        public IActionResult GetBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blogPost)
        {
            if (ModelState.IsValid)
            {
                _blogService.CreateBlog(blogPost);  // Call the service to save the blog post
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blogPost)
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdateBlog(blogPost);  // Call the service to save the blog post
                return RedirectToAction("ViewBlog", "Admin");
            }

            return RedirectToAction("Error");
        }

        public IActionResult ViewCurrentBlog(int id)
        {
            var blog = _blogService.GetBlogById(id);
            var viewModel = new Blogscape.Views.Admin.ViewCurrentBlogModel
            {
                Blog = blog
            };
            return View(viewModel);
        }

        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.DeleteBlog(id);
            return RedirectToAction("ViewBlog", "Admin");
        }
    }
}
