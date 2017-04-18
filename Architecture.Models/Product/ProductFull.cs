using Architecture.Models.Category;
using Architecture.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Product
{
    public class ProductFull : ProductMinimal, IProductFull
    {
        public IEnumerable<CategoryBase> Categories { get; set; }

        public IEnumerable<RatingBase> Ratings { get; set; }
    }
}
