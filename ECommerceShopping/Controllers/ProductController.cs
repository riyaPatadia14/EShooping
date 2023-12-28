using BusinessAccessLayer.Services.Products;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            try
            {
                var productList = await _productService.GetAllProducts(pageNumber);
                return View(productList);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var productDropDown = await _productService.ProductDropDown(new ProductAddDto());
                return PartialView("_Create", productDropDown);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAdd)
        {
            try
            {
                if (productAdd != null)
                {   
                    await _productService.ProductAdd(productAdd);
                }
                return RedirectToAction("Index");
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
                var productById = await _productService.GetProductsById(Id);
                if (productById != null)
                {
                    return PartialView("_Details", productById);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                var productById = await _productService.GetProductsById(Id);
                if (productById != null)
                {
                    return PartialView("_Edit", productById);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewDto productView)
        {
            try
            {
                await _productService.ProductUpdate(productView);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                return PartialView("_Delete");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewDto productDelete)
        {
            try
            {
                await _productService.ProductDelete(productDelete);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
