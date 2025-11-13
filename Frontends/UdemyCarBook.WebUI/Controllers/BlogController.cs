using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CarPricingDtos;
using UdemyCarBook.Dto.CommentDtos;
using UdemyCarBook.Dto.ContactDtos;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.menu1 = "BLOGLAR";
            ViewBag.menu2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/Blogs/GetAllBlogsWithAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorsDto>>(jsonData);



                return View(values);

            }
            return View();
        }



        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.menu1 = "BLOGLAR";
            ViewBag.menu2 = "Blog Detayı ve Yorumlar";
            ViewBag.Blogid = id;

            //Comment Count By Blog Id
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/Comments/CountCommentByBlogId?id=" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCountCommentByBlogIdDto>(jsonData);
            ViewBag.CountCommentByBlogId = values.CountCommentByBlogId;
            return View();
        }


        [HttpGet]
        public  PartialViewResult AddComment(int id)
        {
            ViewBag.Blogid = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            createCommentDto.CreatedDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Blog");
            }
            return View();
        }
    }
}
