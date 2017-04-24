using Architecture.Mappers.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Tests
{
    public class MapperTest
    {
        protected readonly IMapper _mapper;

        public MapperTest()
        {
            _mapper = new MapperConfiguration(MappingConfiguration.Configure).CreateMapper();
        }
    }
}
