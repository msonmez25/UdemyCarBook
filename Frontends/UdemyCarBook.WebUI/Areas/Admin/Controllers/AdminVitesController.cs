using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.VitesDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminVites")]
    public class AdminVitesController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminVitesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Viteses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVitesDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [HttpGet]
        [Route("CreateVites")]
        public IActionResult CreateVites()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateVites")]
        public async Task<IActionResult> CreateVites(CreateVitesDto createVitesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createVitesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Viteses/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminVites", "Admin");
            }
            return View();
        }


        [Route("RemoveVites/{id}")]
        public async Task<IActionResult> RemoveVites(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync("https://localhost:7042/api/Viteses?id=" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminVites", "Admin");
            }
            return View();
        }




        [HttpGet]
        [Route("UpdateVites/{id}")]
        public async Task<IActionResult> UpdateVites(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/Viteses/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateVitesDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("UpdateVites/{id}")]
        public async Task<IActionResult> UpdateVites(UpdateVitesDto updateVitesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateVitesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7042/api/Viteses/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminVites", "Admin");
            }
            return View();
        }
    }
}
