using DtoLayer.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _GetLast5CarComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _GetLast5CarComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7029/api/CarPricing/GetLast5Car");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData= JsonConvert.DeserializeObject<List<GetLast5CarWithBrand>>(readData);
				
				return View(jsonData);
			}
			return View();
		}
	}
}
