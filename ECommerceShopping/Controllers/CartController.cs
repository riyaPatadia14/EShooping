﻿using BusinessAccessLayer.Services.Cart;
using BusinessAccessLayer.Services.Products;
using DataAccessLayer.Helper;
using DataAccessLayer.Models.OrdersSet.Dto;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            try
            {
                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject");

                if (cartItems != null)
                {
                    var totalCartItem = cartItems.Sum(x => x.UnitPrice);
                    ViewBag.Data = cartItems;
                    if (totalCartItem != null)
                    {
                        ViewBag.total = totalCartItem;
                    }
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
                    ProductId = id,
                    Title = productById.Title,
                    Price = productById.Price,
                    ImagePath = productById.ImagePath,
                };

                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject") ?? new List<ProductAddToCartDto>();
                var existingItem = cartItems.FirstOrDefault(item => item.ProductId == addToCart.ProductId);

                if (existingItem != null)
                {
                    existingItem.Qty++;
                    existingItem.UnitPrice = existingItem.Price * existingItem.Qty;

                    HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);
                }
                else
                {
                    addToCart.Qty = 1;
                    addToCart.UnitPrice = addToCart.Price * addToCart.Qty;
                    cartItems.Add(addToCart);
                    HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);
                    return RedirectToAction("Index", "Shop");
                }
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> ProductQuantity(int id, string name)
        {
            try
            {
                var productById = await _productService.GetProductsById(id);
                ProductAddToCartDto addToCart = new ProductAddToCartDto()
                {
                    ProductId = id,
                    Title = productById.Title,
                    Price = productById.Price,
                    ImagePath = productById.ImagePath,
                };

                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject") ?? new List<ProductAddToCartDto>();
                var existingItem = cartItems.FirstOrDefault(item => item.ProductId == addToCart.ProductId);

                if (existingItem != null)
                {
                    if (name == "add")
                    {
                        existingItem.Qty++;
                    }
                    else if (name == "minus" && existingItem.Qty > 1)
                    {
                        existingItem.Qty--;
                    }
                    existingItem.UnitPrice = existingItem.Price * existingItem.Qty;

                    HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);
                }
                else
                {
                    addToCart.Qty = 1;
                    addToCart.UnitPrice = addToCart.Price * addToCart.Qty;
                    cartItems.Add(addToCart);
                    HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);
                    return RedirectToAction("Index", "Shop");
                }
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var productById = await _productService.GetProductsById(id);
                ProductAddToCartDto addToCart = new ProductAddToCartDto()
                {
                    ProductId = id,
                    Title = productById.Title,
                    Price = productById.Price,
                    ImagePath = productById.ImagePath,
                };

                List<ProductAddToCartDto> cartItems = HttpContext.Session.GetObjectFromJson<List<ProductAddToCartDto>>("ComplexObject") ?? new List<ProductAddToCartDto>();
                var existingItem = cartItems.FirstOrDefault(item => item.ProductId == addToCart.ProductId);

                if (existingItem != null)
                {
                    cartItems.Remove(existingItem);
                    HttpContext.Session.SetObjectAsJson("ComplexObject", cartItems);
                    return RedirectToAction("Index", "Shop");
                }
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IActionResult> List(int? pageNumber)
        {
            try
            {
                var orderDetailsList = await _cartService.GetAllOrderDetails(pageNumber);
                return View(orderDetailsList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}