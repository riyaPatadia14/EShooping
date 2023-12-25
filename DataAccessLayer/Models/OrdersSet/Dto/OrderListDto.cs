namespace DataAccessLayer.Models.OrdersSet.Dto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderAmount { get; set; } = 0;
        public int PaymentMode { get; set; } = 0;
        public bool IsDelete { get; set; }
    }
}
