namespace Blogscape.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
