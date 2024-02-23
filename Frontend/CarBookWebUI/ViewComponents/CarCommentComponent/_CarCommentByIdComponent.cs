﻿using DtoLayer.CarComment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebUI.ViewComponents.CarCommentComponent
{
	public class _CarCommentByIdComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarCommentByIdComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7029/api/CarComment?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var readData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData = JsonConvert.DeserializeObject<List<GetCarCommentByIdDto>>(readData);
				return View(jsonData);
			}
			return View();
		}
	}
}
