using Architecture.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Models.Category
{
    public class CategoryFull : CategoryBase, ICategoryFull
    {
        public IEnumerable<ProductBase> Products { get; set; } = new List<ProductBase>();
    }
}
