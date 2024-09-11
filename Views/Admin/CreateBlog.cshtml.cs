using Blogscape.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogscape.Views.Admin
{
    public class CreateBlogModel : PageModel
    {
        [BindProperty]
        public Blog BlogPost { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the blog post to the database (omitted for brevity)

            return RedirectToPage("Index");
        }
    }
}
