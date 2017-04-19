using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Brand;
using Architecture.Repositories.Brand;
using System.Linq;
using AutoMapper;

namespace Architecture.Services.Brand
{
    public class ReadBrandService : IReadBrandService
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
                    .Select(x => _mapper.Map<Database.Entities.Brand, BrandBase>(x))
                    .ToList();
        }
    }
}
