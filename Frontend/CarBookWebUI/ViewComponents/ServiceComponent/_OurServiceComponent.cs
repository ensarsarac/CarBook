using DtoLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebUI.ViewComponents.ServiceComponent
{
    public class _OurServiceComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurServiceComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetServiceDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
    }
}
