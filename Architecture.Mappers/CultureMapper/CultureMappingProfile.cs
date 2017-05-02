using Architecture.Database.Entities;
using Architecture.Models.Common;
using AutoMapper;

namespace Architecture.Mappers.CultureMapper
{
    public class CultureMappingProfile : Profile
    {
        public CultureMappingProfile()
        {
            CreateMap<Culture, CultureBase>();
        }
    }
}
