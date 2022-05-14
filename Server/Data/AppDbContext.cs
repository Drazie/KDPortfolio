using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Category[] categoriesToSeed = new Category[3];
            for (int i = 1; i < 4; i++)
            {
                categoriesToSeed[i - 1] = new Category
                {
                    Id = i,
                    ThumbnailImagePath = "uploads/myplaceholder.jpg",
                    Name = $"Category {i}",
                    Description = $"Description of the Category {i}"
                };
            }

            modelBuilder.Entity<Category>().HasData(categoriesToSeed);
        }
    }
}
