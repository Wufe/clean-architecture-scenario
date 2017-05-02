using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Application.Services;
using Architecture.ViewModels.Account.Manage;
using Architecture.ViewModels.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Mvc.Controllers.Admin
{
    [Authorize]
    [Route("admin/localizations")]
    public class LocalizationAdminController : Controller
    {
        private readonly IAdminLocalizationControllerService _service;

        public LocalizationAdminController(
            IAdminLocalizationControllerService service
        )
        {
            _service = service;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_service.GetIndexViewModel());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(AdminLocalizationIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddLocalization(model);
                return RedirectToAction("Index");
            }
            return View(_service.GetIndexViewModel(model));
        }

        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(string culture, string key)
        {
            _service
                .Delete(culture, key);
            return RedirectToAction("Index");
        }
    }
}