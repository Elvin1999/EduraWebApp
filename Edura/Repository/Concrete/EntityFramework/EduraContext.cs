using Edura.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EduraContext : DbContext
    {
        public EduraContext(DbContextOptions<EduraContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pk => new { pk.ProductId, pk.CategoryId });
        }
    }
}
