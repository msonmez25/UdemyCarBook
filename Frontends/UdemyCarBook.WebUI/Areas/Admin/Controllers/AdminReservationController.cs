using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.CarFeatureDetailDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.ReservationDtos;
using UdemyCarBook.Dto.VitesDtos;
using UdemyCarBook.Dto.YakitTuruDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        [Route("UpdateReservation/{id}")]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            //markaları select list item üzerinden listeleyebilmek için
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7042/api/Cars/GetCarWitBrand");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCarWitBrandsDto>>(jsonData1);

            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName + " / " + x.Model,
                                                    Value = x.CarID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;



            //Lokasyon
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Locations");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData2);

            List<SelectListItem> reservationlocationValues = (from x in values2
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.Name,
                                                                  Value = x.LocationID.ToString()
                                                              }).ToList();
            ViewBag.ReservationlocationValues = reservationlocationValues;



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateReservation/{id}")]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/Reservations/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminReservation", "Admin");
            }
            return View();
        }



        [HttpGet]
        [Route("ChangeReservationStatusToApproved/{id}")]
        public async Task<IActionResult> ChangeReservationStatusToApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7042/api/Reservations/ChangeReservationStatusToApproved?id=" + id);
            return RedirectToAction("Index", "AdminReservation");
        }

        [HttpGet]
        [Route("ChangeReservationStatusToCancaled/{id}")]
        public async Task<IActionResult> ChangeReservationStatusToCancaled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7042/api/Reservations/ChangeReservationStatusToCancaled?id=" + id);
            return RedirectToAction("Index", "AdminReservation");
        }

        [HttpGet]
        [Route("ChangeReservationStatusToReservationReceipt/{id}")]
        public async Task<IActionResult> ChangeReservationStatusToReservationReceipt(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7042/api/Reservations/ChangeReservationStatusToReservationReceipt?id=" + id);
            return RedirectToAction("Index", "AdminReservation");
        }
    }
}
