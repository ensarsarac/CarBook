using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        
    }
}
