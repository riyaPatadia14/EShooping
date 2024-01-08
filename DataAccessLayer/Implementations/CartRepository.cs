using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.OrderDetailsSet;
using DataAccessLayer.Models.OrdersSet.Dto;
namespace DataAccessLayer.Implementations
{
    public class CartRepository : ICart
    {
        private readonly IGenericRepository<OrderDetailsModel> _genericRepository;
        private readonly EShoppingDbContext _eShoppingDbContext;
        public CartRepository(IGenericRepository<OrderDetailsModel> genericRepository, EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext = eShoppingDbContext;
            _genericRepository = genericRepository;
        }
        public async Task AddCartProducts(OrderAddDto orderDetailsAdd)
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

        public async Task<PaginatedList<OrderListDto>> GetAllOrderDetails(int? pageNumber, string searchString)
        {
            try
            {
                await _genericRepository.GetAll();
                var orderDetailsList = (from o in _eShoppingDbContext.Orders
                                        join od in _eShoppingDbContext.OrderDetails on o.Id equals od.OrdersId
                                        join p in _eShoppingDbContext.Products on od.ProductId equals p.Id
                                        select new OrderListDto
                                        {
                                            FirstName = o.FirstName,
                                            LastName = o.LastName,
                                            Qty = od.Qty,
                                            UnitPrice = od.UnitPrice,
                                            Title = p.Title,
                                            ImagePath = p.ImagePath,
                                            InStock = p.InStock
                                            
                                        }).ToList();
                int pageSize = 4;
                if (!String.IsNullOrEmpty(searchString))
                {
                    orderDetailsList = orderDetailsList.Where(p =>
                        p.Title.Contains(searchString) ||
                        p.UnitPrice.ToString().Contains(searchString) ||
                        p.Qty.ToString().Contains(searchString) ||
                        p.LastName.Contains(searchString) ||
                        p.FirstName.Contains(searchString)
                    ).ToList();
                }
                return await PaginatedList<OrderListDto>.CreateAsync(orderDetailsList, pageNumber ?? 1, pageSize);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
