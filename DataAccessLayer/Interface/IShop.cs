using DataAccessLayer.Helper;
using DataAccessLayer.Models.ShopSet;

namespace DataAccessLayer.Interface
{
    public interface IShop
    {
        Task<PaginatedList<ShopProductListDto>> GetClientProductList(int id, int? pageNumber);
        Task<ShopProductViewDto> GetClientProductsById(int id);
    }
}
