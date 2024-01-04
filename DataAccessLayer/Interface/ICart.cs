using DataAccessLayer.Helper;
using DataAccessLayer.Models.OrderDetailsSet.Dto;
using DataAccessLayer.Models.OrdersSet.Dto;
using DataAccessLayer.Models.ProductSet.Dto;

namespace DataAccessLayer.Interface
{
    public interface ICart
    {
        Task AddCartProducts(OrderAddDto orderDetailsAdd);
        Task<PaginatedList<OrderListDto>> GetAllOrderDetails(int? pageNumber, string searchString);
    }
}
