using Architecture.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.ViewModels.Category
{
    public class ListCategoriesViewModel
    {
        public IEnumerable<CategoryBase> Categories { get; set; } = new List<CategoryBase>();
    }
}
