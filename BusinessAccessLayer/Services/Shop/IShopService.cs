using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet.Dto;
using DataAccessLayer.Models.ShopSet;

namespace BusinessAccessLayer.Services.Client
{
    public interface IShopService
    {
        Task<PaginatedList<ShopProductListDto>> GetShopProductList(int categoryId, int brandId, int colorId, int minimumPrice, int maximumPrice, int? pageNumber);
        Task<ProductAddToCartDto> GetShopProductById(int Id);
        Task<IList<ProductHomeDto>> LowestProductPriceList();
        decimal GetMaxPrice();
        decimal GetMinPrice();
    }
}
