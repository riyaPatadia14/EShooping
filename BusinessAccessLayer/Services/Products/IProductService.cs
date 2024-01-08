using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet.Dto;

namespace BusinessAccessLayer.Services.Products
{
    public interface IProductService
    {
        Task ProductAdd(ProductAddDto products);
        Task ProductUpdate(ProductViewDto products);
        Task<ProductViewDto> GetProductsById(int id);
        Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber, string searchString);
        Task<ProductAddDto> ProductDropDown(ProductAddDto products);
        Task ProductDelete(ProductViewDto products);
    }
}
