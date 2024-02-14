using DtoLayer.Banner;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
    public class _EasyWayComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _EasyWayComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Banner");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetBannerDto>>(readData);
                return View(jsonData.FirstOrDefault());
            }

            return View();
        }
    }
}
