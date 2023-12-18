using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet;
using DataAccessLayer.Models.ProductSet.Dto;

namespace BusinessAccessLayer.Services.Products
{
    public interface IProductService
    {
        Task ProductAdd(ProductAddDto products);
        Task ProductUpdate(ProductViewDto products);
        ProductViewDto GetProductsById(int id);
        Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber);
    }
}
