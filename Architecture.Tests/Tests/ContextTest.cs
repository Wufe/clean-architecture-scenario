using Architecture.Tests.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Tests.Tests
{
    public class ContextTest : MapperTest, IDisposable
    {
        protected readonly DataContextTest _context;

        public ContextTest()
        {
            _context = new DataContextTest(
                new ConfigurationBuilder().Build()
            );
        }

        public void Dispose()
        {
            _context
                .Dispose();
        }
    }
}
