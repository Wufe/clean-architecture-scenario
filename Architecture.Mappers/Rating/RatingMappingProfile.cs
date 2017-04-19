using Architecture.Models.Rating;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.Rating
{
    public class RatingMappingProfile : Profile
    {
        public RatingMappingProfile()
        {
            CreateMap<Database.Entities.Rating, RatingBase>();
        }
    }
}
