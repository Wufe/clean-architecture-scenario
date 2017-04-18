using Architecture.Models.Category;
using Architecture.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public interface IProductFull : IProductMinimal
    {
        IEnumerable<CategoryBase> Categories { get; set; }

        IEnumerable<RatingBase> Ratings { get; set; }
    }
}
