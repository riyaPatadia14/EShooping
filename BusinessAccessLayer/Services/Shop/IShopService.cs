using DataAccessLayer.Helper;
using DataAccessLayer.Models.ShopSet;

namespace BusinessAccessLayer.Services.Client
{
    public interface IShopService
    {
        Task<PaginatedList<ShopProductListDto>> GetClientProductList(int? pageNumber);
        Task<ShopProductViewDto> GetClientProductById(int Id);
    }
}
