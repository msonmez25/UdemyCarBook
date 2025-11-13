using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminUser")]
    public class AdminUserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
