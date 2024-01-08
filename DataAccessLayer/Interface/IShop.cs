using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet.Dto;
using DataAccessLayer.Models.ShopSet;

namespace DataAccessLayer.Interface
{
    public interface IShop
    {
        Task<PaginatedList<ShopProductListDto>> GetShopProductList(int categoryId, int brandId, int colorId, int minimumPrice, int maximumPrice, int? pageNumber);
        Task<ProductAddToCartDto> GetShopProductsById(int id);
        Task<IList<ProductHomeDto>> LowestProductPriceList();
        decimal GetMaxPrice();
        decimal GetMinPrice();
    }
}
