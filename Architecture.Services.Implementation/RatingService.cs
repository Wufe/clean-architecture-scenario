using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Architecture.Models;
using Architecture.Repositories;

namespace Architecture.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingService(
            IRatingRepository ratingRepository,
            IMapper mapper
        )
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public IEnumerable<RatingBase> GetAllRatingsBase()
        {
            return
                _ratingRepository
                    .GetAll()
                    .ProjectTo<RatingBase>()
                    .ToList();
        }

        public IEnumerable<RatingBase> GetRatingsBaseByProduct(int productId)
        {
            return
                _ratingRepository
                    .GetAll()
                    .Where(x => x.ProductId == productId)
                    .ProjectTo<RatingBase>()
                    .ToList();
        }
    }
}
