using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        Returned
    }

    public class BookRequest
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public DateTime? ApprovedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string? AdminNotes { get; set; }
    }
}