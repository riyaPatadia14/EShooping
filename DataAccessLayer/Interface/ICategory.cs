using DataAccessLayer.Helper;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Interface
{
    public interface ICategory
    {
        Task<PaginatedList<CategoryListDto>> GetAllCategories(int? pageNumber);
        Task AddCategory(CategoryAddDto category);
        CategoryViewDto GetCategoryById(int id);
        Task UpdateCategory(CategoryViewDto category);
        Task DeleteCategory(CategoriesModel category);
        Task<List<SelectListItem>> GetCategoryList();
        Task DeleteCategory(CategoryViewDto category);
    }
}
