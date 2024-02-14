using DtoLayer.Car;
using DtoLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.CarComponent
{
    public class _CarComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/CarPricing/GetCarPricingDayPrice");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCarDto>>(readData);
                return View(jsonData);
            }
            return View();
        }
    }
}
