using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Architecture.Database.Entities;
using Architecture.Models.Product;
using Architecture.Models.Category;
using Architecture.Models.Rating;
using Architecture.Models.User;

namespace Architecture
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductBase>();
            CreateMap<Product, ProductMinimal>()
                .ForMember(
                    dest => dest.Brand,
                    prop => prop.ResolveUsing<ProductBrandResolver>()
                );

            CreateMap<Product, ProductFull>()
                .ForMember(
                    dest => dest.Brand,
                    prop => prop.ResolveUsing<ProductBrandResolver>()
                )
                .ForMember(
                    dest => dest.Categories,
                    prop => prop.ResolveUsing<ProductCategoriesResolver>()
                )
                .ForMember(
                    dest => dest.Ratings,
                    prop => prop.ResolveUsing<ProductRatingsResolver>()
                );

            CreateMap<Category, CategoryBase>();
            CreateMap<Category, CategoryFull>()
                .ForMember(
                    dest => dest.Products,
                    prop => prop.ResolveUsing<CategoryProductsResolver>()
                );
        }
    }

    class ProductBrandResolver : IValueResolver<Database.Entities.Product, Models.Product.IProductMinimal, string>
    {
        public string Resolve(Product source, IProductMinimal destination, string destMember, ResolutionContext context)
        {
            return source
                .Brand?
                .Name;
        }
    }

    class ProductCategoriesResolver : IValueResolver<Product, IProductFull, IEnumerable<CategoryBase>>
    {
        public IEnumerable<CategoryBase> Resolve(Product source, IProductFull destination, IEnumerable<CategoryBase> destMember, ResolutionContext context)
        {
            return
                source
                    .ProductCategories
                    .Select(
                        pc =>
                            new CategoryBase
                            {
                                Id = pc.Category.Id,
                                Title = pc.Category.Title
                            }
                    );
        }
    }

    class ProductRatingsResolver : IValueResolver<Product, IProductFull, IEnumerable<RatingBase>>
    {
        public IEnumerable<RatingBase> Resolve(Product source, IProductFull destination, IEnumerable<RatingBase> destMember, ResolutionContext context)
        {
            return
                source
                    .Ratings
                    .Select(
                        r =>
                            new RatingBase
                            {
                                Id = r.Id,
                                Comment = r.Comment,
                                Vote = r.Vote,
                                ProductId = source.Id,
                                User = new UserBase
                                {
                                    Id = r.User.Id,
                                    UserName = r.User.UserName
                                },

                            }
                    );
        }
    }

    class CategoryProductsResolver : IValueResolver<Category, ICategoryFull, IEnumerable<ProductBase>>
    {
        public IEnumerable<ProductBase> Resolve(Category source, ICategoryFull destination, IEnumerable<ProductBase> destMember, ResolutionContext context)
        {
            return
                source
                    .ProductCategories
                    .Select(
                        pc =>
                            new ProductBase
                            {
                                Id = pc.Product.Id,
                                Description = pc.Product.Description,
                                Name = pc.Product.Name,
                                Price = pc.Product.Price
                            }
                    );
        }
    }
}
