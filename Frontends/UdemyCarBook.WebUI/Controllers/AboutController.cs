using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.menu1 = "HAKKIMIZDA";
            ViewBag.menu2 = "Vizyonumuz & Misyonumuz";
            return View();
        }
    }
}
