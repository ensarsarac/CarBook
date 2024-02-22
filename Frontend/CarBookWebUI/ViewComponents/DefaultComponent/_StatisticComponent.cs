using DtoLayer.Statistic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _StatisticComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _StatisticComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			#region AraçSayısı-Istatistik
			var responseMessage = await client.GetAsync("https://localhost:7029/api/Statistic/CarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<ResultCarCountDto>(readData);
				ViewBag.carCount = jsonData.CarCount;
			}
			#endregion
			#region LokasyonSayısı-Istatistik
			var responseMessage3 = await client.GetAsync("https://localhost:7029/api/Statistic/LocationCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				var readData3 = await responseMessage3.Content.ReadAsStringAsync();
				var jsonData3 = JsonConvert.DeserializeObject(readData3);
				ViewBag.locationCount = jsonData3;
			}
			#endregion
			#region MarkaSayısı-Istatistik
			var responseMessage4 = await client.GetAsync("https://localhost:7029/api/Statistic/BrandCount");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var readData4 = await responseMessage4.Content.ReadAsStringAsync();
				var jsonData4 = JsonConvert.DeserializeObject(readData4);
				ViewBag.brandCount = jsonData4;
			}
			#endregion
			#region ElektrikliArabaSayısı-Istatistik
			var responseMessage14 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountByFuelElectric");
			if (responseMessage14.IsSuccessStatusCode)
			{
				var readData14 = await responseMessage14.Content.ReadAsStringAsync();
				var jsonData14 = JsonConvert.DeserializeObject(readData14);
				ViewBag.CarCountByFuelElectric = jsonData14;
			}
			#endregion
			return View();
		}
	}
}
