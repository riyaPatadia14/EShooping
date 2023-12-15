using BusinessAccessLayer.Services.Categories;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            try
            {
                var categoryList = await _categoryService.GetAllCategory(pageNumber);
                return View(categoryList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto categoryAdd)
        {
            try
            {
                await _categoryService.CategoryAdd(categoryAdd);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var categoryById = _categoryService.GetCategoryById(Id);
                if (categoryById != null)
                {
                    return PartialView("_Details", categoryById);
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
                var categoryById = _categoryService.GetCategoryById(Id);
                if (categoryById != null)
                {
                    return PartialView("_Edit", categoryById);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewDto category)
        {
            var categoryUpdate = _categoryService.CategoryUpdate(category);
            if (categoryUpdate != null)
            {
                return PartialView(categoryUpdate);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return PartialView();
        }
    }
}
