using Blogscape.Models;

namespace Blogscape.Services
{
    public interface IBlogService
    {
        bool CreateBlog(Blog blog);
        bool DeleteBlog(int id);
        bool UpdateBlog(Blog blog);
        Blog GetBlogById(int id);
        List<Blog> GetBlogs();
    }
}
