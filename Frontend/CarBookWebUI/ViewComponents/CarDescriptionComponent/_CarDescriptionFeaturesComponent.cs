using DtoLayer.CarFeature;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.CarDescriptionComponent
{
	public class _CarDescriptionFeaturesComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDescriptionFeaturesComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7029/api/CarFeature/GetCarFeatureList?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetCarFeatureDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
	}
}
