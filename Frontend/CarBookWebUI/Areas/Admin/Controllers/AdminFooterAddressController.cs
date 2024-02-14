using DtoLayer.FooterAddress;
using DtoLayer.FooterAddress;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    public class AdminFooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

		[Route("UpdateFooterAddress/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateFooterAddress(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7029/api/FooterAddress/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(readData);
				return View(jsonData);
			}
			return View();
		}
		[Route("UpdateFooterAddress/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7029/api/FooterAddress", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
			}

			return View(updateFooterAddressDto);
		}



	}
}
