using DataAccessLayer.Models.OrderDetailsSet.Dto;
using DataAccessLayer.Models.OrdersSet.Dto;
namespace DataAccessLayer.Interface
{
    public interface ICart
    {
        Task AddCartProducts(OrderDetailsListDto orderDetailsAdd);
    }
}
