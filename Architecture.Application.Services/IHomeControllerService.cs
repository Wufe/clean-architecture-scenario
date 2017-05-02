using Architecture.ViewModels.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Application.Services
{
    public interface IHomeControllerService
    {
        HomeIndexViewModel PopulateIndex();
    }
}
