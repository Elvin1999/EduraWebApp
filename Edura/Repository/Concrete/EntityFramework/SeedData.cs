using Edura.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<EduraContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                var products = new[] {
                    new Product(){ Price=1800, ProductName="WebCamera" },
                    new Product(){ Price=235, ProductName="Hand Bag" },
                    new Product(){ Price=1300, ProductName="Photo Camera" },
                    new Product(){ Price=4200 ,ProductName="Sofa" },
                };
                context.Products.AddRange(products);
                var categories = new[] {
                new Category(){  CategoryName="Electronics" },
                new Category(){  CategoryName="Accessories" },
                new Category(){  CategoryName="Furniture" },
                };
                context.Category.AddRange(categories);
                var productcategories = new[] {
                   new ProductCategory(){ Product=products[0],Category=categories[0] },
                   new ProductCategory(){ Product=products[1],Category=categories[0] },
                   new ProductCategory(){ Product=products[3],Category=categories[2] },
                   new ProductCategory(){ Product=products[2],Category=categories[1] },
                };
                context.AddRange(productcategories);
                context.SaveChanges();
            }
        }
    }
}
