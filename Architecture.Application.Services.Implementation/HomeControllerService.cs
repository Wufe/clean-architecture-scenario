using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Services;
using Architecture.ViewModels.Controllers;

namespace Architecture.Application.Services.Implementation
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IProductService _productService;

        public HomeControllerService(
            IProductService productService
        )
        {
            _productService = productService;
        }

        public HomeIndexViewModel GetIndexViewModel()
        {
            return new HomeIndexViewModel()
            {
                MostSeenProducts =
                    _productService
                        .GetMostSeenProductsBase()
            };
        }
    }
}
