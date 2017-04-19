using Architecture.Models.Category;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Category
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Database.Entities.Category, CategoryBase>();
            CreateMap<Database.Entities.Category, CategoryFull>()
                .ForMember(
                    dest => dest.Products,
                    prop => prop.ResolveUsing<CategoryProductsResolver>()
                );

            CreateMap<CategoryBase, Database.Entities.Category>();
        }
    }
}
