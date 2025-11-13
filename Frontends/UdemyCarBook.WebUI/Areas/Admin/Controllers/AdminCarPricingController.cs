using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDetailDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.CommentDtos;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.PricingDtos;
using UdemyCarBook.Dto.VitesDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarPricing")]
    public class AdminCarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("GetCarPricingByCarIdToPricingName/{id}")]
        public async Task<IActionResult> GetCarPricingByCarIdToPricingName(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/CarPricings/GetCarPricingByCarIdToPricingName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarPricingByCarIdToPricingNameDto>>(jsonData);


                //araç marka modeli göstermek için
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync($"https://localhost:7042/api/CarDetails/GetCarInfoByCarId/{id}");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetCarDetailByCarIdDto>(jsonData2);
                ViewBag.CarModelBrand = values2.BrandName + " / " + values2.Model;

                TempData["carid"] = id;

                return View(values);
            }
            return View();

        }


        [HttpGet]
        [Route("CreateCarPricing")]
        public async Task<IActionResult> CreateCarPricing()
        {
            var carID = TempData["carid"];

         

            //araç marka modeli göstermek için
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"https://localhost:7042/api/CarDetails/GetCarInfoByCarId/{carID}");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<GetCarDetailByCarIdDto>(jsonData1);
            ViewBag.CarModelBrand = values1.BrandName + " / " + values1.Model;
            ViewBag.AracId = carID;

            //Lokasyon
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Pricings");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData2);

            List<SelectListItem> PricingValues = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.PricingID.ToString()
                                                  }).ToList();
            ViewBag.pricingValues = PricingValues;

            return View();

        }


        [HttpPost]
        [Route("CreateCarPricing")]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingDto createCarPricingDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/CarPricings/", stringContent);           
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }


        [HttpGet]
        [Route("UpdateCarPricing/{id}")]
        public async Task<IActionResult> UpdateCarPricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/CarPricings/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarPricingDto>(jsonData);
                var pricingID = values.PricingID;
                var carID=values.CarID;

                
                //kiralama türü adı için
                var client1 = _httpClientFactory.CreateClient();
                var responseMessage1 = await client1.GetAsync($"https://localhost:7042/api/Pricings/{pricingID}");
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<UpdatePricingDto>(jsonData1);
                ViewBag.PricingName = values1.Name;

                //araç marka modeli göstermek için
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync($"https://localhost:7042/api/CarDetails/GetCarInfoByCarId/{carID}");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetCarDetailByCarIdDto>(jsonData2);
                ViewBag.CarModelBrand = values2.BrandName + " / " + values2.Model;


                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateCarPricing/{id}")]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingDto updateCarPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/CarPricings/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }



        [Route("RemoveCarPricing/{id}")]
        public async Task<IActionResult> RemoveCarPricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7042/api/CarPricings?id=" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }


       
    }
}
