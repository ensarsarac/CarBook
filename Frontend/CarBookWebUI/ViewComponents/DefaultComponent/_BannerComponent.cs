using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _BannerComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
