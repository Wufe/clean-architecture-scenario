using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        public CartController(

        )
        {

        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}