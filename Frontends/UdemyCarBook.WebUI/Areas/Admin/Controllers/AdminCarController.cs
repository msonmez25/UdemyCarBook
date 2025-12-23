using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Text;
using UdemyCarBook.Dto.BrandDtos;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.VitesDtos;
using UdemyCarBook.Dto.YakitTuruDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Cars/GetCarWitBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWitBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }


       
        [HttpGet]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            //markaları select list item üzerinden listeleyebilmek için
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7042/api/Brands/");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);

            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;


            //Vites Türlerini select list item üzerinden listeleyebilmek için
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Viteses/");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultVitesDto>>(jsonData2);

            List<SelectListItem> vitesValues = (from x in values2
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.VitesID.ToString()
                                                }).ToList();
            ViewBag.VitesValues = vitesValues;


            //Yakıt Türlerini select list item üzerinden listeleyebilmek için
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7042/api/YakitTurus/");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultYakitTuruDto>>(jsonData3);

            List<SelectListItem> yakitTuruValues = (from x in values3
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.YakitTuruID.ToString()
                                                }).ToList();
            ViewBag.YakitTuruValues = yakitTuruValues;

            return View();
        }


        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Cars/",stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }


        [Route("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7042/api/Cars/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }


        [HttpGet]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            //markaları select list item üzerinden listeleyebilmek için
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7042/api/Brands/");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);

            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;


            //Vites Türlerini select list item üzerinden listeleyebilmek için
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7042/api/Viteses/");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultVitesDto>>(jsonData2);

            List<SelectListItem> vitesValues = (from x in values2
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.VitesID.ToString()
                                                }).ToList();
            ViewBag.VitesValues = vitesValues;


            //Yakıt Türlerini select list item üzerinden listeleyebilmek için
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7042/api/YakitTurus/");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultYakitTuruDto>>(jsonData3);

            List<SelectListItem> yakitTuruValues = (from x in values3
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.YakitTuruID.ToString()
                                                    }).ToList();
            ViewBag.YakitTuruValues = yakitTuruValues;



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/Cars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminCar", "Admin");
            }
            return View();
        }



    }
}
