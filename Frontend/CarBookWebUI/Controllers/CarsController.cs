using DtoLayer.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class CarsController : Controller
    {

		public IActionResult Index()
        {
           
            return View();
        }
    }
}
