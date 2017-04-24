using Architecture.Database.Entities.Shared;
using Architecture.Models;
using AutoMapper;

namespace Architecture.Mappers.RatingMapper
{
    public class RatingMappingProfile : Profile
    {
        public RatingMappingProfile()
        {
            CreateMap<Rating, RatingBase>();
        }
    }
}
