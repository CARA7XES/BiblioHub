using Library_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets represent database tables
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }  // ← FIX THIS!

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ISBN).HasMaxLength(20);
                entity.Property(e => e.Genre).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasIndex(e => e.Title);
                entity.HasIndex(e => e.Author);
                entity.HasIndex(e => e.ISBN);
            });

            modelBuilder.Entity<BookRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Book)
                      .WithMany(e => e.BookRequests)
                      .HasForeignKey(e => e.BookId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                      .WithMany(e => e.BookRequests)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.BookId);
                entity.HasIndex(e => e.Status);
            });
        }
    }
}