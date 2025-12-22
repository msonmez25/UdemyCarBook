using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.CarPricingDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7042/api/Cars/GetLast5CarsWithBrand");
            var responseMessage = await client.GetAsync("https://localhost:7042/api/CarPricings/GetCarPricingWithDailyPeriodCars");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
                var values = JsonConvert.DeserializeObject<List<GetCarPricingWithDailyPeriodDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
