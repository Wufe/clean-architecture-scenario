using Architecture.Database.Entities;
using Architecture.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Mappers.UserMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserBase>();
        }
    }
}
