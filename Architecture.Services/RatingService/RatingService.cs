using System.Collections.Generic;
using Architecture.Models.Rating;
using System.Linq;
using AutoMapper;
using Architecture.Repositories.Shared;
using Architecture.Database.Entities.Shared;

namespace Architecture.Services.RatingService
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
                    .Select(x => _mapper.Map<Rating, RatingBase>(x))
                    .ToList();
        }

        public IEnumerable<RatingBase> GetRatingsBaseByProduct(int productId)
        {
            return
                _ratingRepository
                    .GetAll()
                    .Where(x => x.ProductId == productId)
                    .Select(x => _mapper.Map<Rating, RatingBase>(x))
                    .ToList();
        }
    }
}
