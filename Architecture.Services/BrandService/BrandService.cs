using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Brand;
using Architecture.Repositories.Brand;
using System.Linq;
using AutoMapper;
using Architecture.Database.Entities;

namespace Architecture.Services.BrandService
{
    public class ReadBrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public ReadBrandService(
            IBrandRepository brandRepository,
            IMapper mapper
        )
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public IEnumerable<BrandBase> GetAllBrandsBase()
        {
            return
                _brandRepository
                    .GetAll()
                    .Select(x => _mapper.Map<Brand, BrandBase>(x))
                    .ToList();
        }
    }
}
