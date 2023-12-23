using DataAccessLayer.Helper;
using DataAccessLayer.Models.ClientSet;

namespace DataAccessLayer.Interface
{
    public interface IClient
    {
        Task<PaginatedList<ClientProductListDto>> GetClientProductList(int? pageNumber);
        Task<ClientProductViewDto> GetClientProductsById(int id);
    }
}
