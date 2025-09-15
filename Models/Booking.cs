using System.ComponentModel.DataAnnotations;

namespace SuaNhaMVC.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        InProgress,
        Completed,
        Cancelled
    }

    public class Booking
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        public string ServiceId { get; set; } = string.Empty;
        
        [Required]
        public DateTime BookingDate { get; set; }
        
        [Required]
        public string BookingTime { get; set; } = string.Empty;
        
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;
        
        [Required]
        public string CustomerAddress { get; set; } = string.Empty;
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}