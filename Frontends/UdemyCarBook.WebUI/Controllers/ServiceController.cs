using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
      
        public IActionResult Index()
        {
            ViewBag.menu1 = "HİZMETLER";
            ViewBag.menu2 = "Hizmetlerimiz";
            return View();
        }
    }
}
