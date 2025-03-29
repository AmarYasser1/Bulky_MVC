using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category => {
                category.HasKey(c => c.Id);
                category.Property(c => c.Name).IsRequired();
                category.Property(c => c.Name).HasMaxLength(50);
                category.HasData(
                  new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                  new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            });
        }
    }
}
