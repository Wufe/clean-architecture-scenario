using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Models.Rating;
using Architecture.Repositories.Rating;
using System.Linq;
using AutoMapper;
using Architecture.Database.Entities;

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
