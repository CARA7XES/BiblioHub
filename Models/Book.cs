
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 1000)]
        public int AvailableQuantity { get; set; }

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public string? CoverImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<BookRequest> BookRequests { get; set; } = new List<BookRequest>();
    }
}