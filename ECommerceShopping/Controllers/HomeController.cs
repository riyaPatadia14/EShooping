using BusinessAccessLayer.Services.Client;
using ECommerceShopping.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceShopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShopService _shopService;

        public HomeController(ILogger<HomeController> logger, IShopService shopService)
        {
            _shopService = shopService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await _shopService.LowestProductPriceList();
            return View(productList);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}