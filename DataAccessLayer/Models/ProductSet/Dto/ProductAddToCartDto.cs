namespace DataAccessLayer.Models.ProductSet.Dto
{
    public class ProductAddToCartDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
