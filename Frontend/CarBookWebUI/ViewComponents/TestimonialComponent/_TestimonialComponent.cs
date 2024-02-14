using DtoLayer.About;
using DtoLayer.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.TestimonialComponent
{
	public class _TestimonialComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _TestimonialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var urlData = await client.GetAsync("https://localhost:7029/api/Testimonial");
			if(urlData != null) {

				var readData = await urlData.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetTestimonialDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
	}
}
