using DtoLayer.Brand;
using DtoLayer.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Areas.Admin.ViewComponents.DashboardComponent
{
	public class _AdminDashboardStatisticComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardStatisticComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			#region GünlükORtalamaFiyat-Istatistik
			var responseMessage5 = await client.GetAsync("https://localhost:7029/api/Statistic/GetDayAvgPrice");
			if (responseMessage5.IsSuccessStatusCode)
			{
				var readData5 = await responseMessage5.Content.ReadAsStringAsync();
				var jsonData5 = JsonConvert.DeserializeObject(readData5);
				ViewBag.avgRentPriceForDaily = jsonData5;
			}
			#endregion
			#region EnÇokKiralananMarka-Istatistik
			var responseMessage9 = await client.GetAsync("https://localhost:7029/api/Statistic/GetMaxBrandCar");
			if (responseMessage9.IsSuccessStatusCode)
			{
				var readData9 = await responseMessage9.Content.ReadAsStringAsync();
				var jsonData9 = JsonConvert.DeserializeObject<MaxBrandCarDto>(readData9);
				ViewBag.maxBrandCar = jsonData9.BrandName;
			}
			#endregion
			#region EnPahalıAracınModelVeMarkası-Istatistik
			var responseMessage15 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarBrandAndModelByRentPriceMax");
			if (responseMessage15.IsSuccessStatusCode)
			{
				var readData15 = await responseMessage15.Content.ReadAsStringAsync();
				var jsonData15 = JsonConvert.DeserializeObject<MaxCarBrandAndModel>(readData15);
				ViewBag.BrandAndModelByMaxPrice = jsonData15.BrandAndModelName;
			}
			#endregion
			#region 1000KmDüşükAracSayısı-Istatistik
			var responseMessage11 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountKmSmaller1000");
			if (responseMessage11.IsSuccessStatusCode)
			{
				var readData11 = await responseMessage11.Content.ReadAsStringAsync();
				var jsonData11 = JsonConvert.DeserializeObject(readData11);
				ViewBag.CarKmSmaller1000 = jsonData11;
			}
			#endregion#region 1000KmDüşükAracSayısı-Istatistik
			return View();
		}
	}
}
