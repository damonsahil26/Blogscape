using Blogscape.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogscape.Views.Admin
{
    public class ViewCurrentBlogModel : PageModel
    {
        [BindProperty]
        public Blog Blog { get; set; }

        public void OnGet()
        {
        }
    }
}
