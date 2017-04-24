using Architecture.Models;
using System.Collections.Generic;

namespace Architecture.Services
{
    public interface IRatingService
    {
        IEnumerable<RatingBase> GetAllRatingsBase();
        IEnumerable<RatingBase> GetRatingsBaseByProduct(int productId);
    }
}
