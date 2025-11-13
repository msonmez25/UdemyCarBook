using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.YakitTuruDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminYakitTuru")]
    public class AdminYakitTuruController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminYakitTuruController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/YakitTurus");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultYakitTuruDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        [Route("CreateYakitTuru")]
        public IActionResult CreateYakitTuru()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateYakitTuru")]
        public async Task<IActionResult> CreateYakitTuru(CreateYakitTuruDto createYakitTuruDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createYakitTuruDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/YakitTurus/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminYakitTuru", "Admin");
            }
            return View();
        }


        [Route("RemoveYakitTuru/{id}")]
        public async Task<IActionResult> RemoveYakitTuru(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7042/api/YakitTurus?id=" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminYakitTuru", "Admin");
            }
            return View();
        }




        [HttpGet]
        [Route("UpdateYakitTuru/{id}")]
        public async Task<IActionResult> UpdateYakitTuru(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/YakitTurus/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateYakitTuruDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateYakitTuru/{id}")]
        public async Task<IActionResult> UpdateYakitTuru(UpdateYakitTuruDto updateYakitTuruDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateYakitTuruDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/YakitTurus/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminYakitTuru", "Admin");
            }
            return View();
        }
    }
}
