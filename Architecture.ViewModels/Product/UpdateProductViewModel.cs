using Architecture.Models.Brand;
using Architecture.Models.Category;
using Architecture.Models.Product;
using Architecture.Models.Rating;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.ViewModels.Product
{
    public class UpdateProductViewModel : GenericEditProductViewModel
    {
        public ProductBase Product { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        public SelectListItem SelectedBrand { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> SelectedCategories { get; set; }

        public IEnumerable<RatingBase> Ratings { get; set; }


    }
}
