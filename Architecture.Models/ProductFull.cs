using System.Collections.Generic;

namespace Architecture.Models
{
    public class ProductFull : ProductBase
    {
        public IEnumerable<CategoryBase> Categories { get; set; }

        public IEnumerable<RatingBase> Ratings { get; set; }
    }
}
