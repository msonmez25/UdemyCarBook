using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.RentACarDtos;
using UdemyCarBook.Dto.VitesDtos;
using UdemyCarBook.Dto.YakitTuruDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminRentACar")]
    public class AdminRentACarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRentACarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/RentACars/GetRentACarByCarNameLocationName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetRentACarByCarNameLocationNameDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        [Route("CreateRentACar")]
        public async Task<IActionResult> CreateRentACar()
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

            List<SelectListItem> locationValues = (from x in values2
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.Name,
                                                                  Value = x.LocationID.ToString()
                                                              }).ToList();
            ViewBag.locationValues = locationValues;




            return View();
        }


        [HttpPost]
        [Route("CreateRentACar")]
        public async Task<IActionResult> CreateRentACar(CreateRentACarDto createRentACarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRentACarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/RentACars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminRentACar", "Admin");
            }
            return View();
        }



        [Route("RemoveRentACar/{id}")]
        public async Task<IActionResult> RemoveRentACar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7042/api/RentACars?id=" +id);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminRentACar", "Admin");
            }
            return View();
        }


        [HttpGet]
        [Route("ChangeRentACarAvaibleToTrue/{id}")]
        public async Task<IActionResult> ChangeRentACarAvaibleToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7042/api/RentACars/ChangeRentACarAvaibleToTrue?id=" + id);
            return RedirectToAction("Index", "AdminRentACar");
        }

        [HttpGet]
        [Route("ChangeRentACarAvaibleToFalse/{id}")]
        public async Task<IActionResult> ChangeRentACarAvaibleToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7042/api/RentACars/ChangeRentACarAvaibleToFalse?id=" + id);
            return RedirectToAction("Index", "AdminRentACar");
        }



        [HttpGet]
        [Route("UpdateRentACar/{id}")]
        public async Task<IActionResult> UpdateRentACar(int id)
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

            List<SelectListItem> locationValues = (from x in values2
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.LocationID.ToString()
                                                   }).ToList();
            ViewBag.locationValues = locationValues;



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/RentACars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRentACarDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpPost]
        [Route("UpdateRentACar/{id}")]
        public async Task<IActionResult> UpdateRentACar(UpdateRentACarDto updateRentACarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRentACarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/RentACars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminRentACar", "Admin");
            }
            return View();
        }

    }
}
