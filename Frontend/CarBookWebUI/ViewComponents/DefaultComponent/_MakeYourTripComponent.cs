using DtoLayer.Car;
using DtoLayer.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;

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
            var token = User as ClaimsPrincipal;
            var tokenuser = token.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if(tokenuser != null) {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenuser);
                var responseMessage = await client.GetAsync("https://localhost:7029/api/Location");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var readData = await responseMessage.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject<List<GetLocationDto>>(readData);
                    ViewBag.locations = new SelectList(jsonData, "LocationID", "Name");
                    
                }
            }

            return View();
        }
	}
}
