using DataAccessLayer.Models.OrderDetailsSet.Dto;

namespace DataAccessLayer.Models.ProductSet.Dto
{
    public class ProductAddToCartDto : OrderDetailsListDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
