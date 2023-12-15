using DataAccessLayer.Models.BrandSet;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.ColorSet;

namespace DataAccessLayer.Models.ProductSet
{
    public class ProductsModel : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual int CategoryId { get; set; }
        public virtual int BrandId { get; set; }
        public virtual int ColorId { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string InStock { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public CategoriesModel Categories { get; set; }
        public BrandModel Brands { get; set; }
        public ColorModel Color { get; set; }
    }
}
