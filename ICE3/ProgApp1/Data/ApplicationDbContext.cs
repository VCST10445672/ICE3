using Microsoft.EntityFrameworkCore;
using ProgApp1.Models;

namespace ProgApp1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }

        public DbSet<StudentResult> StudentResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentResult>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
