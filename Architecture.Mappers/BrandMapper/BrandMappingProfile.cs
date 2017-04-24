using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;

namespace Architecture.Mappers.BrandMapper
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandBase>();
        }
    }
}
