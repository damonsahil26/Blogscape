using Microsoft.AspNetCore.Mvc;

namespace Blogscape.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CreateBlog()
        {
            return View();
        }
    }
}
