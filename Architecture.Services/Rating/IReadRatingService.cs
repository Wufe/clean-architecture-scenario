using Architecture.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Services.Rating
{
    public interface IReadRatingService
    {
        IEnumerable<RatingBase> GetAllRatingsBase();
    }
}
