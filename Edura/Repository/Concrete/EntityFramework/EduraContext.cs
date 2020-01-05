using Edura.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public class EduraContext:DbContext
    {
        public EduraContext(DbContextOptions<EduraContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pk => new { pk.ProductId, pk.CategoryId });
        }
    }
}
