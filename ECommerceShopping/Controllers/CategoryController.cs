using BusinessAccessLayer.Services.Categories;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShopping.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {
            try
            {
                ViewData["CurrentFilter"] = searchString;

                var categoryList = await _categoryService.GetAllCategory(pageNumber, searchString);
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
                if (categoryAdd != null)
                {
                    await _categoryService.CategoryAdd(categoryAdd);
                }
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
            if (category != null)
            {
                await _categoryService.CategoryUpdate(category);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var categoryById = _categoryService.GetCategoryById(Id);
                if (categoryById != null)
                {
                    return PartialView("_Delete", categoryById);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewDto category)
        {
            if (category != null)
            {
                await _categoryService.CategoryDelete(category);
            }
            return RedirectToAction("Index");
        }
    }
}
