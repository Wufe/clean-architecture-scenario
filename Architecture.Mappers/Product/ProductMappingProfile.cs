using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Database.Entities.Product, ProductBase>();
            CreateMap<Database.Entities.Product, ProductMinimal>()
                .ForMember(
                    dest => dest.Brand,
                    prop => prop.ResolveUsing<ProductBrandResolver>()
                );

            CreateMap<Database.Entities.Product, ProductFull>()
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

            CreateMap<ProductBase, Database.Entities.Product>();
        }
    }
}
