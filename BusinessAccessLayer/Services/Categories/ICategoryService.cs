using DataAccessLayer.Helper;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Categories
{
    public interface ICategoryService
    {
        Task CategoryAdd(CategoryAddDto addcategory);
        Task CategoryUpdate(CategoryViewDto category);
        CategoryViewDto GetCategoryById(int id);
        Task<PaginatedList<CategoryListDto>> GetAllCategory(int? pageNumber, string searchString);
        Task<List<SelectListItem>> GetCategoryList();
        Task CategoryDelete(CategoryViewDto category);
    }
}
