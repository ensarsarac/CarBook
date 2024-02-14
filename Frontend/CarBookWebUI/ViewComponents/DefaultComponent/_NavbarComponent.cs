using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _NavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        } 
    }
}
