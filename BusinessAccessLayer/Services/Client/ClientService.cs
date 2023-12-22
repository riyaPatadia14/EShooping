using DataAccessLayer.Helper;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ClientSet;
using DataAccessLayer.Models.ProductSet.Dto;

namespace BusinessAccessLayer.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClient _clientRepostiory;
        public ClientService(IClient clientRepository)
        {
            _clientRepostiory = clientRepository;
        }
        public async Task<PaginatedList<ClientProductListDto>> GetClientProductList(int? pageNumber)
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
        public async Task<ClientProductViewDto> GetClientProductById(int id)
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
