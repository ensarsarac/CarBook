using DtoLayer.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Controllers
{
    public class CarsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CarsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
        {           
            return View();
        }
        public async Task<IActionResult> CarDetails(int id)
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7029/api/Car/GetCarByIdWithBrand?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<GetCarByIdWithBrandDto>(readData);
				return View(jsonData);
			}
			return View();
		}
    }
}
