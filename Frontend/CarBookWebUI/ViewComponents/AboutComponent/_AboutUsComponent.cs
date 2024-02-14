using DtoLayer.About;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.AboutComponent
{
	public class _AboutUsComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AboutUsComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client =  _httpClientFactory.CreateClient();
			var urlData = await client.GetAsync("https://localhost:7029/api/About");
			if(urlData != null)
			{
				var readData = await urlData.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetAboutDto>>(readData);
				return View(jsonData.FirstOrDefault());
			}
			return View();
		}
	}
}
