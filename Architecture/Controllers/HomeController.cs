using Architecture.Application.Services;
using Architecture.ViewModels.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Architecture.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IHomeControllerService _service;

        public HomeController(
            IStringLocalizer<HomeController> localizer,
            IHomeControllerService service
        )
        {
            _localizer = localizer;
            _service = service;
        }

        public IActionResult Index()
        {
            return View(
                _service
                    .GetIndexViewModel()
            );
            //return Content(
            //    String.Format($"Current culture: {CultureInfo.CurrentCulture.Name}.\n" +
            //    $"{_localizer["Say hi"]}")

            //);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
