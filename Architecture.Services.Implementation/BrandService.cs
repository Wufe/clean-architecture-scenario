using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Architecture.Models;
using Architecture.Repositories;

namespace Architecture.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(
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
                    .ProjectTo<BrandBase>()
                    .ToList();
        }
    }
}
