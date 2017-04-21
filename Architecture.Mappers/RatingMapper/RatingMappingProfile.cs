using Architecture.Database.Entities;
using Architecture.Database.Entities.Shared;
using Architecture.Models.Rating;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
