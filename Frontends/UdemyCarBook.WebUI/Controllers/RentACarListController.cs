using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDetailDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.RentACarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.menu1 = "Araç Kİrala";
            ViewBag.menu2 = "En Uygun Araçlar";

            //var bookpickdate = TempData["bookpickdate"];
            //ViewBag.bookpickdate = bookpickdate;

            //var bookoffdate = TempData["bookoffdate"];
            //ViewBag.bookoffdate = bookoffdate;

            //var timepick = TempData["timepick"];
            //ViewBag.timepick = timepick;

            //var timeoff = TempData["timeoff"];
            //ViewBag.timeoff = timeoff;

            var locationID = TempData["locationID"];
            ViewBag.locationID = locationID;
            id = int.Parse(locationID.ToString());


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/RentACars?locationID={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(jsonData);             
                
               

                return View(values);
            }
            return View();
        }
    }
}
