using DtoLayer.Location;
using DtoLayer.RentACar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ResultRentACarDto model)
        {
            ViewBag.v = model.LocationID;
            ViewBag.v2 = model.DropOffDate;
            ViewBag.v1 = model.PickUpDate;
            ViewBag.v3 = model.PickUpTime;
            ViewBag.v4 = model.DropOffTime;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/RentACars/GetRentACarListByLocationWithCar?id={model.LocationID}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultRentACarIdDto>>(readData);
                
                return View(jsonData);
            }
            
            return View();
        }
    }
}
