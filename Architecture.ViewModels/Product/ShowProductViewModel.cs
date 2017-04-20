using Architecture.Models.Brand;
using Architecture.Models.Category;
using Architecture.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.ViewModels.Product
{
    public class ShowProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public BrandBase Brand { get; set; }

        public IEnumerable<CategoryBase> Categories { get; set; }

        public IEnumerable<RatingBase> Ratings { get; set; }
    }
}
