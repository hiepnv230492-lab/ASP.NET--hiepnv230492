using System.ComponentModel.DataAnnotations;

namespace SuaNhaMVC.Models
{
    public class WebsiteContent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string Key { get; set; } = string.Empty;
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string? Content { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public string? Link { get; set; }
        
        public ContentType Type { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public int Order { get; set; } = 0;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum ContentType
    {
        Banner,
        AboutUs,
        Service,
        Testimonial,
        Contact,
        Footer,
        Hero,
        Feature
    }
}