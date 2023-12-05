using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogNET.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
