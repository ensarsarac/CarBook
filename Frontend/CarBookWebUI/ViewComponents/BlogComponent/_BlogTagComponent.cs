using DtoLayer.Blog;
using DtoLayer.TagCloud;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogComponent
{
    public class _BlogTagComponent: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogTagComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/TagCloud/GetTagCloudListByIdWithBlog?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetTagCloudById>>(readData);
                return View(jsonData);
            }
            return View();
        }
    }
}
