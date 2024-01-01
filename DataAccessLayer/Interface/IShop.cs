using DataAccessLayer.Helper;
using DataAccessLayer.Models.ProductSet.Dto;
using DataAccessLayer.Models.ShopSet;

namespace DataAccessLayer.Interface
{
    public interface IShop
    {
        Task<PaginatedList<ShopProductListDto>> GetClientProductList(int id, int? pageNumber);
        Task<ProductAddToCartDto> GetClientProductsById(int id);
        Task<IList<ProductHomeDto>> LowestProductPriceList();
    }
}
