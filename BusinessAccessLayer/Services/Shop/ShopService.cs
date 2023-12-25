using DataAccessLayer.Helper;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ShopSet;
using DataAccessLayer.Models.ProductSet.Dto;

namespace BusinessAccessLayer.Services.Client
{
    public class ShopService : IShopService
    {
        private readonly IShop _clientRepostiory;
        public ShopService(IShop clientRepository)
        {
            _clientRepostiory = clientRepository;
        }
        public async Task<PaginatedList<ShopProductListDto>> GetClientProductList(int? pageNumber)
        {
            try
            {
                return await _clientRepostiory.GetClientProductList(pageNumber);
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
                return await _clientRepostiory.GetClientProductsById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
