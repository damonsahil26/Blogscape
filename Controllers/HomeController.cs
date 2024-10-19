using Blogscape.Models;
using Blogscape.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogscape.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            ViewData["Blogs"]= _blogService.GetBlogs();
            return View();
        } 
        
        public IActionResult ViewBlog(int id)
        {
            var blog = _blogService.GetBlogById(id);
            var viewModel = new Blogscape.Views.Home.ViewBlogModel
            {
                Blog = blog, // Assuming 'Blog' is a property in your ViewBlogModel
                             // You can add more properties to ViewBlogModel if needed
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
