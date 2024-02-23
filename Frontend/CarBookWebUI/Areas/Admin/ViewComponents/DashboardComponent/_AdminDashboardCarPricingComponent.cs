using DtoLayer.CarPricing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebUI.Areas.Admin.ViewComponents.DashboardComponent
{
	public class _AdminDashboardCarPricingComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardCarPricingComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
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
