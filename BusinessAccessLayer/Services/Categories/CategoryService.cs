using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;

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
            await _categoryRepository.AddCategory(addcategory);
        }
        public async Task CategoryDelete(CategoriesModel category)
        {
            await _categoryRepository.DeleteCategory(category);
        }
        public async Task CategoryUpdate(CategoryViewDto category)
        {
            await _categoryRepository.UpdateCategory(category);
        }
        public async Task<PaginatedList<CategoryListDto>> GetAllCategory(int? pageNumber)
        {
            return await _categoryRepository.GetAllCategories(pageNumber);
        }
        public CategoryViewDto GetCategoryById(int id)
        {
           return _categoryRepository.GetCategoryById(id);
        }
    }
}
