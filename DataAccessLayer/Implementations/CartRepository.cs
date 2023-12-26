using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.OrderDetailsSet;
using DataAccessLayer.Models.OrderDetailsSet.Dto;

namespace DataAccessLayer.Implementations
{
    public class CartRepository : ICart
    {
        private readonly IGenericRepository<OrderDetailsModel> _genericRepository;
        public CartRepository()
        {
        }
        public async Task AddCartProducts(OrderDetailsAddDto orderDetailsAdd)
        {
            var orderDetailsAddToCart = new OrderDetailsModel
            {
                Id = orderDetailsAdd.Id,
                OrdersId = orderDetailsAdd.OrdersId,
                ProductId = orderDetailsAdd.ProductId,
                Qty = orderDetailsAdd.Qty,
                UnitPrice = orderDetailsAdd.UnitPrice,
            };
            await _genericRepository.Add(orderDetailsAddToCart);
        }
    }
}
