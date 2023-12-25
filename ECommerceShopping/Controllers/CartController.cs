using BusinessAccessLayer.Services.Products;
using DataAccessLayer.Data;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.OrderDetailsSet.Dto;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace ECommerceShopping.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            try
            {
                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject");

                if (cartItems != null)
                {
                    ViewBag.Data = cartItems;

                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> Order(int id)
        {
            try
            {
                var productById = await _productService.GetProductsById(id);
                ProductAddToCartDto addToCart = new ProductAddToCartDto()
                {
                    Id = id,
                    Title = productById.Title,
                    Price = productById.Price,
                    ImagePath = productById.ImagePath,
                };

                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject") ?? new List<ProductAddToCartDto>();
                var existingItem = cartItems.FirstOrDefault(item => item.Id == addToCart.Id);

                cartItems.Add(addToCart);

                HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);

                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}