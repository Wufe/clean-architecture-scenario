using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.ViewModels.Product
{
    public class ListProductsViewModel
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();

        [MinLength(3)]
        public string SearchText { get; set; }
    }
}
