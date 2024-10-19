using Blogscape.Models;
using Blogscape.Services;
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
    }
}
