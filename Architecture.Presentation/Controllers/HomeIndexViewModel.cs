using System.Collections.Generic;
using Architecture.Models;

namespace Architecture.ViewModels.Controllers
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductBase> MostSeenProducts { get; set; }
    }
}
