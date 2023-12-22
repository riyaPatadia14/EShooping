using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.OrderDetailsSet;

namespace DataAccessLayer.Implementations
{
    public class CartRepository : ICart
    {
        private readonly IGenericRepository<OrderDetailsModel> _genericRepository;
        private readonly EShoppingDbContext _eShoppingDbContext;
        public CartRepository(EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext= eShoppingDbContext;
        }
        private bool HasCart(string productId)
        {
            var result = _eShoppingDbContext.OrderDetails.FirstOrDefault();
            return result == null;
        }
    }
}
