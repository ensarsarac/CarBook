using DtoLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {         
            return View();
        }

    }
}
