using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
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


            //3 AutoCarCount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7042/api/Statistics/GetCarCountByTranmissionIsAutoCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int deger3 = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.carCountByTranmissionIsAutoCount = values3.CarCountByTranmissionIsAutoCount;
                ViewBag.deger3 = deger3;
            }


            //4 ManuelCarCount
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7042/api/Statistics/GetCarCountByTranmissionIsManuelCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int deger4 = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.carCountByTranmissionIsManuelCount = values4.CarCountByTranmissionIsManuelCount;
                ViewBag.deger4 = deger4;
            }


            //5 ElectricByCarCount
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:7042/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int deger5 = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.carCountByFuelElectric = values5.CarCountByFuelElectric;
                ViewBag.deger5 = deger5;
            }


            //6 DiselOrFuelByCarCount
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:7042/api/Statistics/GetCarCountByFuelGasolineOrDisel");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int deger6 = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.carCountByFuelGasolineOrDisel = values6.CarCountByFuelGasolineOrDisel;
                ViewBag.deger6 = deger6;
            }

            
            //7 Günlük Araç Kira En Düşük Fiyat
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:7042/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int deger7 = random.Next(100, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values7.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.deger7 = deger7;
            }


            //8 Günlük Araç Kira En Yüksek Fiyat
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:7042/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int deger8 = random.Next(100, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values8.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.deger8 = deger8;
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



            //10 Haftalık Araç Kira Ortlama Fiyat
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client9.GetAsync("https://localhost:7042/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int deger10 = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.avgRentPriceForWeekly = values10.AvgRentPriceForWeekly.ToString("0.00");
                ViewBag.deger10 = deger10;
            }

            // 11 Aylık Araç Kira Ortlama Fiyat
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:7042/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int deger11 = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.avgRentPriceForMonthly = values11.AvgRentPriceForMonthly.ToString("0.00");
                ViewBag.deger11 = deger11;
            }


            //12 En Fazla Markalı Araç
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync("https://localhost:7042/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int deger12 = random.Next(100, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.brandNameByMaxCar = values12.BrandNameByMaxCar;
                ViewBag.deger12 = deger12;
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

            //14 Blog Sayısı
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:7042/api/Statistics/GetBlogCount");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int deger14 = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.blogCount = values14.BlogCount;
                ViewBag.deger14 = deger14;
            }

            //15 Yazar Sayısı
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:7042/api/Statistics/GetAuthorCount");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int deger15 = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.authorCount = values15.AuthorCount;
                ViewBag.deger15 = deger15;
            }

            //16 En Çok Yorum Alan Blog
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:7042/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int deger16 = random.Next(100, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.blogTitleByMaxBlogComment = values16.BlogTitleByMaxBlogComment;
                ViewBag.deger16 = deger16;
            }




            return View();
        }
    }
}
