using LeThanhThan_K2023_ThiGk.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace LeThanhThan_K2023_ThiGk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<EnrollmentEntity> Enroll { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>()
                 .HasMany(e => e.Enrollments)
                 .WithOne(c => c.Course)
                 .HasForeignKey(c => c.CourseId)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
