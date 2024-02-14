using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _ScriptComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
