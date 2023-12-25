namespace DataAccessLayer.Models.OrderDetailsSet.Dto
{
    public class OrderDetailsListDto
    {
        public int Id { get; set; }
        public int OrdersId { get; set; } = 0;
        public int ProductId { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public bool IsDelete { get; set; }
    }
}
