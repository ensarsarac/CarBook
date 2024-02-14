﻿using DtoLayer.Categories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.BlogComponent
{
    public class _BlogCategoriesComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogCategoriesComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Category/GetCategoryListWithGroupBy");
            if (responseMessage.IsSuccessStatusCode)
            {
                var readData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<GetCategoryListGroupBy>>(readData);
                return View(jsonData);
            }
            return View();
        }
    }
}
