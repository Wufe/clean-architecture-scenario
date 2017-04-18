using Architecture.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architecture.Database
{
    public static class SeedExtensions
    {
        public static void EnsureSeedData(this DataContext context)
        {
            if (!context.Products.Any())
            {
                context.Brands.Add(
                    new Brand
                    {
                        Name = "Sony"
                    }
                );
                context.Categories.Add(
                    new Category
                    {
                        Title = "Elettronica"
                    }
                );
                context.SaveChanges();
                context.Products.Add(
                    new Product
                    {
                        BrandId = 1,
                        Description = "???",
                        Name = "MSCCCCC",
                        Price = 2.00
                    }
                );
                context.SaveChanges();
                context.ProductCategories.Add(
                    new ProductCategory
                    {
                        ProductId = 1,
                        CategoryId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
