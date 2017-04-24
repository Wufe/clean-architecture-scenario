using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;

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
