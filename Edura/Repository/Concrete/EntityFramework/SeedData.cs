using Edura.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                    new Product(){ Price=1800, ProductName="WebCamera", Image="product1_thumb.jpg"
                    , Description="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "Voluptatum consequatur dolorum explicabo mollitia cum?",
                     HtmlContent="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "<b>Voluptatum consequatur dolorum explicabo mollitia cum?</b>",
                      DateAdded=DateTime.Now.AddDays(-30)
                    },
                    new Product(){ Price=235, ProductName="Hand Bag" , Image="product4_thumb.jpg"
                      , Description="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "Voluptatum consequatur dolorum explicabo mollitia cum?"
                    ,
                     HtmlContent="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "<b>Voluptatum consequatur dolorum explicabo mollitia cum?</b>",
                      DateAdded=DateTime.Now.AddDays(-15)
                    },
                    new Product(){ Price=1300, ProductName="Photo Camera" , Image="product1_thumb.jpg"
                      , Description="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "Voluptatum consequatur dolorum explicabo mollitia cum?"
                    ,
                     HtmlContent="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "<b>Voluptatum consequatur dolorum explicabo mollitia cum?</b>",
                       DateAdded=DateTime.Now.AddDays(-7)
                    },
                    new Product(){ Price=4200 ,ProductName="Sofa", Image="product3_thumb.jpg"
                      , Description="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "Voluptatum consequatur dolorum explicabo mollitia cum?"
                    ,
                     HtmlContent="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "<b>Voluptatum consequatur dolorum explicabo mollitia cum?</b>",
                       DateAdded=DateTime.Now.AddDays(-1)
                    },
                     new Product(){ Price=4200 ,ProductName="Sofa", Image="product2_thumb.jpg"
                      , Description="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "Voluptatum consequatur dolorum explicabo mollitia cum?"
                    ,
                     HtmlContent="Lorem ipsum dolor sit amet consectetur adipisicing elit." +
                    " Suscipit tenetur asperiores ab assumenda, debitis dicta qui nisi, " +
                    "fuga officia ipsum laboriosam sit doloribus non. " +
                    "<b>Voluptatum consequatur dolorum explicabo mollitia cum?</b>",
                       DateAdded=DateTime.Now.AddDays(-1)
                    },
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
                var images = new[] {
                 new Image(){ ImageName="product1_thumb.jpg", Product=products[0] },
                 new Image(){ ImageName="product2_thumb.jpg", Product=products[0] },
                 new Image(){ ImageName="product3_thumb.jpg", Product=products[0] },
                 new Image(){ ImageName="product4_thumb.jpg", Product=products[0] },
                 new Image(){ ImageName="product1_thumb.jpg", Product=products[1] },
                 new Image(){ ImageName="product2_thumb.jpg", Product=products[1] },
                 new Image(){ ImageName="product3_thumb.jpg", Product=products[1] },
                 new Image(){ ImageName="product4_thumb.jpg", Product=products[1] },
                 new Image(){ ImageName="product1_thumb.jpg", Product=products[2] },
                 new Image(){ ImageName="product2_thumb.jpg", Product=products[2] },
                 new Image(){ ImageName="product3_thumb.jpg", Product=products[2] },
                 new Image(){ ImageName="product4_thumb.jpg", Product=products[2] },
                 new Image(){ ImageName="product1_thumb.jpg", Product=products[3] },
                 new Image(){ ImageName="product2_thumb.jpg", Product=products[3] },
                 new Image(){ ImageName="product3_thumb.jpg", Product=products[3] },
                 new Image(){ ImageName="product4_thumb.jpg", Product=products[3] },

                };
                context.AddRange(images);
                var attributes = new[] {
                    new ProductAttribute(){ Attribute="Display", Value="15.6",Product=products[4] },
                    new ProductAttribute(){ Attribute="Processor", Value="Intel I7 - 8750",Product=products[4] },
                    new ProductAttribute(){ Attribute="Ram Memory", Value="16GB",Product=products[4] },
                    new ProductAttribute(){ Attribute="Hard Disk", Value="1 TB",Product=products[4] },
                    new ProductAttribute(){ Attribute="Color", Value="Black",Product=products[4] },
                    new ProductAttribute(){ Attribute="Display", Value="15.6",Product=products[0] },
                    new ProductAttribute(){ Attribute="Processor", Value="Intel I7 - 8750",Product=products[0] },
                    new ProductAttribute(){ Attribute="Ram Memory", Value="16GB",Product=products[0] },
                    new ProductAttribute(){ Attribute="Hard Disk", Value="1 TB",Product=products[0] },
                    new ProductAttribute(){ Attribute="Color", Value="Black",Product=products[0] },
                    new ProductAttribute(){ Attribute="Display", Value="15.6",Product=products[1] },
                    new ProductAttribute(){ Attribute="Processor", Value="Intel I7 - 8750",Product=products[1] },
                    new ProductAttribute(){ Attribute="Ram Memory", Value="16GB",Product=products[1] },
                    new ProductAttribute(){ Attribute="Hard Disk", Value="1 TB",Product=products[1] },
                    new ProductAttribute(){ Attribute="Color", Value="Black",Product=products[1]},
                    new ProductAttribute(){ Attribute="Display", Value="15.6",Product=products[2] },
                    new ProductAttribute(){ Attribute="Processor", Value="Intel I7 - 8750",Product=products[2] },
                    new ProductAttribute(){ Attribute="Ram Memory", Value="16GB",Product=products[2] },
                    new ProductAttribute(){ Attribute="Hard Disk", Value="1 TB",Product=products[2] },
                    new ProductAttribute(){ Attribute="Color", Value="Black",Product=products[2] },
                    new ProductAttribute(){ Attribute="Display", Value="15.6",Product=products[3] },
                    new ProductAttribute(){ Attribute="Processor", Value="Intel I7 - 8750",Product=products[3] },
                    new ProductAttribute(){ Attribute="Ram Memory", Value="16GB",Product=products[3] },
                    new ProductAttribute(){ Attribute="Hard Disk", Value="1 TB",Product=products[3] },
                    new ProductAttribute(){ Attribute="Color", Value="Black",Product=products[3] },
                };
                context.AddRange(attributes);
                context.SaveChanges();
            }
        }
    }
}
