﻿using Architecture.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Tests
{
    public class ServicesTest : RepositoriesTest
    {
        protected readonly ProductService _productService;
        protected readonly UserService _userService;

        public ServicesTest()
        {
            _userService = new UserService(
                _userRepository
            );

            _productService = new ProductService(
                new LoggerFactory().CreateLogger<ProductService>(),
                _mapper,
                _productRepository,
                _productCategoryRepository,
                _productUserRepository,
                _userService
            );
        }
    }
}
