using DtoLayer.Brand;
using DtoLayer.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Car/GetCarListWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarWithBrandDtos>>(readData);
                return View(jsonData);
            }
            return View();
        }
        [Route("CreateCar")]
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Brand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBrandDtos>>(readData);
                ViewBag.brands = new SelectList(jsonData, "brandID", "name");
            }
            return View();
        }
        [Route("CreateCar")]
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Car", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new {area="Admin"});
            }
            var responseMessage2 = await client.GetAsync("https://localhost:7029/api/Brand");
            var readData2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsonData2 = JsonConvert.DeserializeObject<List<GetBrandDtos>>(readData2);
            ViewBag.brands = new SelectList(jsonData2, "brandID", "name");
            return View(createCarDto);
        }
        [Route("RemoveCar/{id}")]
        [HttpGet]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Car?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
        }
        [Route("UpdateCar/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Car/{id}");
            var responseMessage2 = await client.GetAsync("https://localhost:7029/api/Brand");
            if (responseMessage.IsSuccessStatusCode)
            {

                var readData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData2 = JsonConvert.DeserializeObject<List<GetBrandDtos>>(readData2);
                ViewBag.brands = new SelectList(jsonData2, "brandID", "name");

                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateCarDto>(readData);
                return View(jsonData);
            }
            return View();
        }
        [Route("UpdateCar/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Car", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            var responseMessage2 = await client.GetAsync("https://localhost:7029/api/Brand");
            var readData2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsonData2 = JsonConvert.DeserializeObject<List<GetBrandDtos>>(readData2);
            ViewBag.brands = new SelectList(jsonData2, "brandID", "name");

            return View(updateCarDto);
        }


    }
}
