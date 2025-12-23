using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
