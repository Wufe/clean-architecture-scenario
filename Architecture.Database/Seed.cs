using Architecture.Database.Entities;
using Microsoft.AspNetCore.Identity;
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

                var adminUser = new User
                {
                    UserName = "wufe92@gmail.com",
                    NormalizedUserName = "WUFE92@GMAIL.COM",
                    Email = "wufe92@gmail.com",
                    NormalizedEmail = "WUFE92@GMAIL.COM",
                    SecurityStamp = "0eafa1d5-7e50-4294-8a0e-2220a0c188da",
                    ConcurrencyStamp = "16bb08a7-b820-4e90-8528-17b577d3ad18"
                };

                var passwordHasher = new PasswordHasher<User>();
                var hashedPassword = passwordHasher.HashPassword(adminUser, "1234Aa_");
                adminUser.PasswordHash = hashedPassword;

                context.Users.Add(adminUser);

                context.SaveChanges();
            }
        }
    }
}
