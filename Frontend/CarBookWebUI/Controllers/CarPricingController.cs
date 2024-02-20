using DtoLayer.About;
using DtoLayer.CarPricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebUI.Controllers
{
    public class CarPricingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient();
			var urlData = await client.GetAsync("https://localhost:7029/api/CarPricing/GetCarPricingWithTimePeriod");
			if (urlData != null)
			{
				var readData = await urlData.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<ResultCarPricingWithAllTimePeriod>>(readData);
				return View(jsonData);
			}
			return View();
		}
    }
}
