using DataAccessLayer.Models.OrdersSet;

namespace DataAccessLayer.Models.OrderDetailsSet
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; } = 0;
        public virtual int ProductId { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public OrdersModel Orders { get; set; }
    }
}
