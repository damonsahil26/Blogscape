using System.ComponentModel.DataAnnotations;

namespace Blogscape.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 50)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdatedDate { get; set; }
    }
}
