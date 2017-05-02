using System.Collections.Generic;
using Architecture.Models;

namespace Architecture.ViewModels.Category
{
    public class ListCategoriesViewModel
    {
        public IEnumerable<CategoryBase> Categories { get; set; } = new List<CategoryBase>();
    }
}
