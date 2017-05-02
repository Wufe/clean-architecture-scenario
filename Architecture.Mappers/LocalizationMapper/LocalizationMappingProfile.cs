using Architecture.Database.Entities;
using Architecture.Models.Common;
using AutoMapper;
using Microsoft.Extensions.Localization;

namespace Architecture.Mappers.LocalizationMapper
{
    public class LocalizationMappingProfile : Profile
    {
        public LocalizationMappingProfile()
        {
            CreateMap<LocalizedString, LocalizedStringBase>()
                .ForMember(
                    dest => dest.Key,
                    prop => prop.MapFrom(x => x.Name)
                )
                .ReverseMap()
                    .ConstructUsing(
                        x => new LocalizedString(x.Key, x.Value)
                    );

            CreateMap<LocalizedString, LocalizedStringFull>()
                .ForMember(
                    dest => dest.Key,
                    prop => prop.MapFrom(x => x.Name)
                )
                .ReverseMap()
                .ConstructUsing(
                    x => new LocalizedString(x.Key, x.Value)
                );

            CreateMap<Localization, LocalizedString>()
                .ConstructUsing(
                    x => new LocalizedString(x.Key, x.Value)
                );

            CreateMap<Localization, LocalizedStringBase>()
                .ReverseMap();

            CreateMap<Localization, LocalizedStringFull>()
                .ReverseMap();
        }
    }
}
