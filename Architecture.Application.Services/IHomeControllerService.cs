using Architecture.ViewModels.Controllers;

namespace Architecture.Application.Services
{
    public interface IHomeControllerService
    {
        HomeIndexViewModel GetIndexViewModel();
    }
}
