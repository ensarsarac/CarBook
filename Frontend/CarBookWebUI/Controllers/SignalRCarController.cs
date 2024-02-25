using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
