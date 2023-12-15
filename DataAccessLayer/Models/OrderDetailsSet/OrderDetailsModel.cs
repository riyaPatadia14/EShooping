using DataAccessLayer.Models.OrdersSet;

namespace DataAccessLayer.Models.OrderDetailsSet
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public OrdersModel Orders { get; set; }
    }
}
