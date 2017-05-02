using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Mvc.Controllers;
using Xunit;

namespace Architecture.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnAView()
        {
            MyMvc
                .Controller<HomeController>()
                .Calling(c => c.Index())
                .ShouldReturn()
                    .View();
        }

    }
}
