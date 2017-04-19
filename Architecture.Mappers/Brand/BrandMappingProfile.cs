using Architecture.Models.Brand;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Brand
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Database.Entities.Brand, BrandBase>();
        }
    }
}
