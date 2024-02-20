using DtoLayer.Location;
using DtoLayer.Reservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carid = id;    
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLocationDto>>(readData);
                ViewBag.locations = new SelectList(jsonData, "LocationID", "Name");
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Reservations", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View(createReservationDto);
        }



    }
}
