using Architecture.Database.Entities;
using Architecture.Models.Category;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.CategoryMapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryBase>();
            CreateMap<Category, CategoryFull>()
                .ForMember(
                    dest => dest.Products,
                    prop => prop.ResolveUsing<CategoryProductsResolver>()
                );

            CreateMap<CategoryBase, Category>();
        }
    }
}
