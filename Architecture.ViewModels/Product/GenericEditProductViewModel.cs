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
        public ProductFull Product { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        public string SelectedBrand { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<string> SelectedCategories { get; set; }

        public IEnumerable<RatingBase> Ratings { get; set; }
    }
}
