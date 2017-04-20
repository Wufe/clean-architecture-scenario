using Architecture.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.RatingService
{
    public interface IReadRatingService
    {
        IEnumerable<RatingBase> GetAllRatingsBase();
        IEnumerable<RatingBase> GetRatingsBaseByProduct(int productId);
    }
}
