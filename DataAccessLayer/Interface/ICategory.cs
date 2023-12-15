using DataAccessLayer.Helper;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;

namespace DataAccessLayer.Interface
{
    public interface ICategory
    {
        Task<PaginatedList<CategoryListDto>> GetAllCategories(int? pageNumber);
        Task AddCategory(CategoryAddDto category);
        CategoryViewDto GetCategoryById(int id);
        Task UpdateCategory(CategoryViewDto category);
        Task DeleteCategory(CategoriesModel category);
    }
}