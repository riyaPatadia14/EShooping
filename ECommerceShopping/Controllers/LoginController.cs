using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
