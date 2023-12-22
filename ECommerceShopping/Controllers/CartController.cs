using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
