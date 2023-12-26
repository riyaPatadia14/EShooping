using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategory _categoryRepository;
        public CategoryService(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CategoryAdd(CategoryAddDto addcategory)
        {
            try
            {

                await _categoryRepository.AddCategory(addcategory);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task CategoryDelete(CategoriesModel category)
        {
            try
            {
                await _categoryRepository.DeleteCategory(category);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task CategoryUpdate(CategoryViewDto category)
        {
            try
            {

                await _categoryRepository.UpdateCategory(category);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PaginatedList<CategoryListDto>> GetAllCategory(int? pageNumber)
        {
            try
            {

                return await _categoryRepository.GetAllCategories(pageNumber);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CategoryViewDto GetCategoryById(int id)
        {
            try
            {

                return _categoryRepository.GetCategoryById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SelectListItem>> GetCategoryList()
        {
            try
            {

                return await _categoryRepository.GetCategoryList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
