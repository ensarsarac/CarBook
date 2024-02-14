using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.BlogComponent
{
    public class _TagCloudComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
