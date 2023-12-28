using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
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
        public async Task<PaginatedList<ShopProductListDto>> GetClientProductList(int id, int? pageNumber)
        {
            try
            {
                return await _shopRepostiory.GetClientProductList(id, pageNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ShopProductViewDto> GetClientProductById(int id)
        {
            try
            {
                return await _shopRepostiory.GetClientProductsById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
