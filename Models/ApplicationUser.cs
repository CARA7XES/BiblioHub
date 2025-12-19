using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<BookRequest> BookRequests { get; set; } = new List<BookRequest>();
    }
}