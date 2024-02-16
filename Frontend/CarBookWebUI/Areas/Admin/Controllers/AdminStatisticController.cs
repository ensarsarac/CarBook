using DtoLayer.Author;
using DtoLayer.Blog;
using DtoLayer.Brand;
using DtoLayer.Car;
using DtoLayer.Statistic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region AraçSayısı-Istatistik
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Statistic/CarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultCarCountDto>(readData);
                ViewBag.carCount = jsonData.CarCount;
            }
            #endregion
            #region YazarSayısı-Istatistik
            var responseMessage2 = await client.GetAsync("https://localhost:7029/api/Statistic/AuthorCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var readData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData2 = JsonConvert.DeserializeObject<ResultAuthorCountDto>(readData2);
                ViewBag.authorCount = jsonData2.AuthorCount;
            }
            #endregion
            #region LokasyonSayısı-Istatistik
            var responseMessage3 = await client.GetAsync("https://localhost:7029/api/Statistic/LocationCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var readData3 = await responseMessage3.Content.ReadAsStringAsync();
                var jsonData3 = JsonConvert.DeserializeObject(readData3);
                ViewBag.locationCount = jsonData3;
            }
            #endregion
            #region MarkaSayısı-Istatistik
            var responseMessage4 = await client.GetAsync("https://localhost:7029/api/Statistic/BrandCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var readData4 = await responseMessage4.Content.ReadAsStringAsync();
                var jsonData4 = JsonConvert.DeserializeObject(readData4);
                ViewBag.brandCount = jsonData4;
            }
            #endregion
            #region GünlükORtalamaFiyat-Istatistik
            var responseMessage5 = await client.GetAsync("https://localhost:7029/api/Statistic/GetDayAvgPrice");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var readData5 = await responseMessage5.Content.ReadAsStringAsync();
                var jsonData5 = JsonConvert.DeserializeObject(readData5);
                ViewBag.avgRentPriceForDaily = jsonData5;
            }
            #endregion
            #region HaftalıkOrtalamaFiyat-Istatistik
            var responseMessage6 = await client.GetAsync("https://localhost:7029/api/Statistic/GetWeekAvgPrice");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var readData6 = await responseMessage6.Content.ReadAsStringAsync();
                var jsonData6 = JsonConvert.DeserializeObject<WeekAvgPriceDto>(readData6);
                ViewBag.avgRentPriceForWeekly = jsonData6.WeekAvgPrice.ToString("0.00");
            }
            #endregion
            #region AylıkOrtalamaFiyat-Istatistik
            var responseMessage7 = await client.GetAsync("https://localhost:7029/api/Statistic/GetMonthAvgPrice");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var readData7 = await responseMessage7.Content.ReadAsStringAsync();
                var jsonData7 = JsonConvert.DeserializeObject(readData7);
                ViewBag.avgRentPriceForMonthly = jsonData7;
            }
            #endregion
            #region OtomatikArabaSayısı-Istatistik
            var responseMessage8 = await client.GetAsync("https://localhost:7029/api/Statistic/GetAutomaticCarCount");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var readData8 = await responseMessage8.Content.ReadAsStringAsync();
                var jsonData8 = JsonConvert.DeserializeObject(readData8);
                ViewBag.AutomaticCarCount = jsonData8;
            }
            #endregion
            #region EnÇokKiralananMarka-Istatistik
            var responseMessage9 = await client.GetAsync("https://localhost:7029/api/Statistic/GetMaxBrandCar");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var readData9 = await responseMessage9.Content.ReadAsStringAsync();
                var jsonData9 = JsonConvert.DeserializeObject<MaxBrandCarDto>(readData9);
                ViewBag.maxBrandCar = jsonData9.BrandName;
            }
            #endregion
            #region EnFazlaYorumAlanBlog-Istatistik
            var responseMessage10 = await client.GetAsync("https://localhost:7029/api/Statistic/GetMaxCommentByBlog");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var readData10 = await responseMessage10.Content.ReadAsStringAsync();
                var jsonData10 = JsonConvert.DeserializeObject<MaxCommentByBlog>(readData10);
                ViewBag.maxCommentByBlog = jsonData10.BlogName;
            }
            #endregion
            #region 1000KmDüşükAracSayısı-Istatistik
            var responseMessage11 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountKmSmaller1000");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var readData11 = await responseMessage11.Content.ReadAsStringAsync();
                var jsonData11 = JsonConvert.DeserializeObject(readData11);
                ViewBag.CarKmSmaller1000 = jsonData11;
            }
            #endregion#region 1000KmDüşükAracSayısı-Istatistik
            #region BenzinliArabaSayısı-Istatistik
            var responseMessage12 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountByFuelBenzine");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var readData12 = await responseMessage12.Content.ReadAsStringAsync();
                var jsonData12 = JsonConvert.DeserializeObject(readData12);
                ViewBag.CarCountByFuelBenzine = jsonData12;
            }
            #endregion
            #region DizelArabaSayısı-Istatistik
            var responseMessage13 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountByFuelDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var readData13 = await responseMessage13.Content.ReadAsStringAsync();
                var jsonData13 = JsonConvert.DeserializeObject(readData13);
                ViewBag.CarCountByFuelDiesel = jsonData13;
            }
            #endregion
            #region ElektrikliArabaSayısı-Istatistik
            var responseMessage14 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var readData14 = await responseMessage14.Content.ReadAsStringAsync();
                var jsonData14 = JsonConvert.DeserializeObject(readData14);
                ViewBag.CarCountByFuelElectric = jsonData14;
            }
            #endregion
            #region EnPahalıAracınModelVeMarkası-Istatistik
            var responseMessage15 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarBrandAndModelByRentPriceMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var readData15 = await responseMessage15.Content.ReadAsStringAsync();
                var jsonData15 = JsonConvert.DeserializeObject<MaxCarBrandAndModel>(readData15);
                ViewBag.BrandAndModelByMaxPrice = jsonData15.BrandAndModelName;
            }
            #endregion
            #region EnDüşükAracınModelVeMarkası-Istatistik
            var responseMessage16 = await client.GetAsync("https://localhost:7029/api/Statistic/GetCarBrandAndModelByRentPriceMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var readData16 = await responseMessage16.Content.ReadAsStringAsync();
                var jsonData16 = JsonConvert.DeserializeObject<MinCarBrandAndModel>(readData16);
                ViewBag.BrandAndModelByMinPrice = jsonData16.BrandAndModelName;
            }
            #endregion
            return View();
        }
    }
}
