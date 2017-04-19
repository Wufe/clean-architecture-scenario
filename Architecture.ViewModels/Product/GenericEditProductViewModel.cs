using Architecture.Models.Product;
using Architecture.Models.Rating;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.ViewModels.Product
{
    public class GenericEditProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IEnumerable<SelectListItem> BrandsList { get; set; }

        public string SelectedBrand { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; }

        public IEnumerable<string> SelectedCategories { get; set; }

        public IEnumerable<RatingBase> RatingsList { get; set; }
    }
}
