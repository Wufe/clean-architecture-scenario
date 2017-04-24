using Architecture.Database.Entities;
using Architecture.Mappers.Common;
using Architecture.Repositories.EntityFramework;
using Architecture.Repositories.EntityFramework.Shared;
using Architecture.Services;
using Architecture.Tests.Database;
using Architecture.Tests.Tests;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Architecture.Tests.Services.Implementation
{
    public class ProductServiceTest : ServicesTest
    {
        [Fact]
        public void SearchProductsBaseShouldWorkWithName()
        {
            var product = new Product
            {
                Brand = new Brand
                {
                    Name = "Sony"
                },
                Description = "Description",
                Price = 13,
                Name = "Product with MSC keyword in name"
            };
            _context
                .Set<Product>()
                .Add(product);

            _context
                .SaveChanges();
            var result =
                _productService
                    .SearchProductsBase("msc");
            Assert.True(result.Any(
                x =>
                    x.Name.Equals("Product with MSC keyword in name")
            ));
            _context
                .Set<Product>()
                .Remove(product);
            _context
                .SaveChanges();
        }

        [Fact]
        public void SearchProductsBaseShouldWorkWithBrandName()
        {
            var product = new Product
            {
                Brand = new Brand
                {
                    Name = "aMSCZ"
                },
                Description = "Description",
                Price = 13,
                Name = "Product with keyword in brand name"
            };

            _context
                .Set<Product>()
                .Add(product);

            _context
                .SaveChanges();

            var result =
                _productService
                    .SearchProductsBase("msc");
            Assert.True(result.Any(
                x =>
                    x.Name.Equals("Product with keyword in brand name")
            ));

            _context
                .Set<Product>()
                .Remove(product);
        }

        [Fact]
        public void SearchProductsBaseShouldWorkWithDescription()
        {
            var product = new Product
            {
                Brand = new Brand
                {
                    Name = "Sony"
                },
                Description = "A long MsC description.",
                Price = 13,
                Name = "Product with keyword in description"
            };

            _context
                .Set<Product>()
                .Add(product);

            _context
                .SaveChanges();

            var result =
                _productService
                    .SearchProductsBase("msc");
            Assert.True(result.Any(
                x =>
                    x.Name.Equals("Product with keyword in description")
            ));

            _context
                .Set<Product>()
                .Remove(product);
        }

        [Fact]
        public void SearchProductsBaseShouldReturnNoResults()
        {
            var product = new Product
            {
                Brand = new Brand
                {
                    Name = "Sony"
                },
                Description = "A long description.",
                Price = 13,
                Name = "Product with no keyword"
            };

            _context
                .Set<Product>()
                .Add(product);

            _context
                .SaveChanges();

            var result =
                _productService
                    .SearchProductsBase("msc");
            Assert.False(result.Any(
                x =>
                    x.Name.Equals("Product with no keyword")
            ));

            _context
                .Set<Product>()
                .Remove(product);
        }
    }
}
