using BusinessAccessLayer.Services.Brand;
using BusinessAccessLayer.Services.Categories;
using BusinessAccessLayer.Services.Client;
using BusinessAccessLayer.Services.Color;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.ClientSet;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceShopping.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IColorService _colorService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ClientController(IClientService clientService, IColorService colorService, IBrandService brandService, ICategoryService categoryService)
        {
            _brandService = brandService;
            _colorService = colorService;
            _categoryService = categoryService;
            _clientService = clientService;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            try
            {
                var Categories = await _categoryService.GetCategoryList();
                ViewBag.Categories = Categories;
                var Colors = await _colorService.GetAllColor();
                ViewBag.Colors = Colors;
                var Brands = await _brandService.GetAllBrandList();
                ViewBag.Brands = Brands;
                var productList = await _clientService.GetClientProductList(pageNumber);
                return View(productList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var productById = await _clientService.GetClientProductById(Id);
                if (productById != null)
                {
                    return View(productById);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
