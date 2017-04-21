using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Architecture.Models.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.ProductUserMapper
{
    public class ProductUserMappingProfile : Profile
    {
        public ProductUserMappingProfile()
        {
            CreateMap<ProductUser, ProductCart>()
                .ForMember(
                    dest => dest.Quantity,
                    prop => prop.MapFrom(source => source.Quantity)
                )
                .ForMember(
                    dest => dest.Id,
                    prop => prop.MapFrom(source => source.Product.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    prop => prop.MapFrom(source => source.Product.Name)
                ).ForMember(
                    dest => dest.Description,
                    prop => prop.MapFrom(source => source.Product.Description)
                ).ForMember(
                    dest => dest.Price,
                    prop => prop.MapFrom(source => source.Product.Price)
                );
        }
    }
}
