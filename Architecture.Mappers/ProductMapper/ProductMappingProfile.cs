using Architecture.Database.Entities;
using Architecture.Models.Brand;
using Architecture.Models.Category;
using Architecture.Models.Product;
using AutoMapper;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.ProductMapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductBase>();
            CreateMap<Product, ProductMinimal>()
                .ForMember(
                    dest => dest.Brand,
                    prop => prop.MapFrom(x => x.Brand)
                );

            CreateMap<Product, ProductFull>()
                .ForMember(
                    dest => dest.Brand,
                    prop => prop.MapFrom(x => x.Brand)
                )
                .ForMember(
                    dest => dest.Categories,
                    prop => prop.ResolveUsing<ProductCategoriesResolver>()
                )
                .ForMember(
                    dest => dest.Ratings,
                    prop => prop.ResolveUsing<ProductRatingsResolver>()
                );

            CreateMap<ProductBase, Product>();
        }
    }
}
