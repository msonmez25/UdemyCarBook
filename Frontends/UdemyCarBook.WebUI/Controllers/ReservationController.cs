using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.ReservationDtos;
using UdemyCarBook.Dto.YakitTuruDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.menu1 = "REZERVASYON";
            ViewBag.menu2 = "Rezervasyon Bilgileri";
            ViewBag.carID = id;

            //Araç görseli
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"https://localhost:7042/api/Cars/{id}");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<ResultCarWitBrandsDto>(jsonData1);
            ViewBag.ImageUrl = values1.CoverImageUrl;



            //Lokasyon
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> reservationlocationValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.LocationID.ToString()
                                                   }).ToList();
            ViewBag.ReservationlocationValues = reservationlocationValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Reservations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }



    }
}
