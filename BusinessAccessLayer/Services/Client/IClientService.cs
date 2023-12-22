using DataAccessLayer.Helper;
using DataAccessLayer.Models.ClientSet;

namespace BusinessAccessLayer.Services.Client
{
    public interface IClientService
    {
        Task<PaginatedList<ClientProductListDto>> GetClientProductList(int? pageNumber);
        Task<ClientProductViewDto> GetClientProductById(int Id);
    }
}
