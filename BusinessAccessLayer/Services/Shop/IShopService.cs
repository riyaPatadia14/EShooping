using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet.Dto;
using DataAccessLayer.Models.ShopSet;

namespace BusinessAccessLayer.Services.Client
{
    public interface IShopService
    {
        Task<PaginatedList<ShopProductListDto>> GetClientProductList(int id, int? pageNumber);
        Task<ProductAddToCartDto> GetClientProductById(int Id);
    }
}
