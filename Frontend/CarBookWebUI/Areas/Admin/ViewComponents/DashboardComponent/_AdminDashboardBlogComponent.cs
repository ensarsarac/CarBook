using DtoLayer.Blog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebUI.Areas.Admin.ViewComponents.DashboardComponent
{
	public class _AdminDashboardBlogComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardBlogComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7029/api/Blogs");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetBlogListDto>>(readData);
				return View(jsonData.Take(5).ToList());
			}
			return View();
		}
	}
}
