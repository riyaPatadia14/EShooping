using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit() 
        { 
            return View(); 
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
