using DataAccessLayer.Models.OrdersSet;

namespace DataAccessLayer.Models.OrderDetailsSet
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int OrdersId { get; set; } = 0;
        public int ProductId { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public bool IsDelete { get; set; }
        public OrdersModel Orders { get; set; } = new OrdersModel();
    }
}