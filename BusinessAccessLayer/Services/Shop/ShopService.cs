using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet.Dto;
using DataAccessLayer.Models.ShopSet;

namespace BusinessAccessLayer.Services.Client
{
    public class ShopService : IShopService
    {
        private readonly IShop _shopRepostiory;
        public ShopService(IShop shopRepository)
        {
            _shopRepostiory = shopRepository;
        }
        public async Task<PaginatedList<ShopProductListDto>> GetShopProductList(int categoryId, int brandId, int colorId, int minimumPrice, int maximumPrice, int? pageNumber)
        {
            try
            {
                var shopProductList = await _shopRepostiory.GetShopProductList(categoryId, brandId, colorId, minimumPrice, maximumPrice, pageNumber);
                return shopProductList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductAddToCartDto> GetShopProductById(int id)
        {
            try
            {
                return await _shopRepostiory.GetShopProductsById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<ProductHomeDto>> LowestProductPriceList()
        {
            try
            {
                return await _shopRepostiory.LowestProductPriceList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal GetMaxPrice()
        {
           return _shopRepostiory.GetMaxPrice();
        }

        public decimal GetMinPrice()
        {
           return _shopRepostiory.GetMinPrice();
        }
    }
}
