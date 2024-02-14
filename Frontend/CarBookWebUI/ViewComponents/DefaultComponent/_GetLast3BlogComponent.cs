using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DtoLayer.Blog;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _GetLast3BlogComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _GetLast3BlogComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7029/api/Blogs/GetLast3BlogList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<Get3LastBlogDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
	}
}
