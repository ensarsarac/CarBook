using DtoLayer.FooterAddress;
using DtoLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.FooterAddressComponent
{
    public class _ContactAddressComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactAddressComponent(IHttpClientFactory httpClientFactory)
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
