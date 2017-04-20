using Architecture.Database.Entities;
using Architecture.Models.Brand;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
