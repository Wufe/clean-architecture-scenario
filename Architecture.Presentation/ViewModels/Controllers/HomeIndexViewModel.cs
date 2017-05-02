using Architecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Presentation.ViewModels.Controllers
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductBase> MostSeenProducts { get; set; }
    }
}
