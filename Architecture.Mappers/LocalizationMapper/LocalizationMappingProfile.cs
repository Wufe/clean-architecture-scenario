using Architecture.Database.Entities;
using AutoMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.LocalizationMapper
{
    public class LocalizationMappingProfile : Profile
    {
        public LocalizationMappingProfile()
        {
            CreateMap<Localization, LocalizedString>()
                .ForMember(
                    dest => dest.Name,
                    prop => prop.MapFrom(x => x.Key)
                )
                .ForMember(
                    dest => dest.ResourceNotFound,
                    prop => prop.MapFrom(x => x.Key)
                );
        }
    }
}
