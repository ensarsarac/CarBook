using DtoLayer.Car;
using DtoLayer.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.DefaultComponent
{
	public class _MakeYourTripComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _MakeYourTripComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetLocationDto>>(readData);
                ViewBag.locations = new SelectList(jsonData, "LocationID", "Name");
                return View();
            }
            return View();
        }
	}
}
