using DtoLayer.FooterAddress;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _FooterComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _FooterComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7029/api/FooterAddress");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetFooterAddress>>(readData);
				return View(jsonData.FirstOrDefault());
			}
			return View();
		}
    }
}
