using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CarFeatureDetailDtos;
using UdemyCarBook.Dto.ReviewDtos;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentByCarIdComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCommentByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;


			//2 ReviewCountByCarId
			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Reviews/GetReviewCountByCarId?id=" + id);
			if (responseMessage2.IsSuccessStatusCode)
			{

				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultReviewCountByCarIdDto>(jsonData2);
				ViewBag.reviewCount = values2.ReviewCount;

			}


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7042/api/Reviews?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);
				return View(values);
			}

		


			return View();
		}
	}
}
