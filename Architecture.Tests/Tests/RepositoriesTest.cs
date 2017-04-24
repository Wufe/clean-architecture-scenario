using Architecture.Repositories.EntityFramework;
using Architecture.Repositories.EntityFramework.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Tests
{
    public class RepositoriesTest : ContextTest
    {
        protected readonly EFProductRepository _productRepository;
        protected readonly EFProductCategoryRepository _productCategoryRepository;
        protected readonly EFProductUserRepository _productUserRepository;
        protected readonly EFUserRepository _userRepository;

        public RepositoriesTest()
        {
            _productRepository = new EFProductRepository(
                _context
            );

            _productCategoryRepository = new EFProductCategoryRepository(
                _context
            );

            _productUserRepository = new EFProductUserRepository(
                _context
            );

            _userRepository = new EFUserRepository(
                _context
            );
        }
    }
}
