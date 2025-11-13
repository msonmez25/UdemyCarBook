using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();

            //1 CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int deger = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.CarCount;
                ViewBag.deger = deger;
            }


            //2 BrandCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Statistics/GetBrandCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int deger2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.brandCount = values2.BrandCount;
                ViewBag.deger2 = deger2;
            }


            //9 Günlük Araç Kira Ortlama Fiyat
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:7042/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int deger9 = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.avgRentPriceForDaily = values9.AvgRentPriceForDaily.ToString("0.00");
                ViewBag.deger9 = deger9;
            }


            //13 Loksayon Sayısı
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:7042/api/Statistics/GetLocationCount");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int deger13 = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.locationCount = values13.LocationCount;
                ViewBag.deger13 = deger13;
            }

            return View();

        }
    }
}
