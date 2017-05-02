using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

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
                        Price = 2.00,
                        ProductCategories = new List<ProductCategory>()
                        {
                            new ProductCategory
                            {
                                ProductId = 1,
                                CategoryId = 1
                            }
                        }
                    }
                );
                context.SaveChanges();

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

                context.Cultures.AddRange(new Culture[]
                {
                    new Culture()
                    {
                        Name = "it"
                    },
                    new Culture()
                    {
                        Name = "en-US"
                    }
                });

                context.Localizations.AddRange(new Localization[]
                {
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Test accents",
                        Value = "Test degli accènti"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Most seen products",
                        Value = "Prodotti più visti"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Say hi",
                        Value = "Di' ciao"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Home",
                        Value = "Home"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Admin",
                        Value = "Amministrazione"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Admin Panel",
                        Value = "Pannello di Amministrazione"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Update Categories",
                        Value = "Modifica Categorie"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Update Products",
                        Value = "Modifica Prodotti"
                    },
                    new Localization()
                    {
                        Culture = "it",
                        Key = "Update Brands",
                        Value = "Modifica Brand"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Test accents",
                        Value = "Test accents"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Most seen products",
                        Value = "Most seen products"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Say hi",
                        Value = "Say hi"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Home",
                        Value = "Home"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Admin",
                        Value = "Admin"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Admin Panel",
                        Value = "Admin Panel"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Update Categories",
                        Value = "Update Categories"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Update Products",
                        Value = "Update Products"
                    },
                    new Localization()
                    {
                        Culture = "en-US",
                        Key = "Update Brands",
                        Value = "Update Brands"
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
