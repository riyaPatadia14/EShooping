using DataAccessLayer.Models.BrandSet;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.ColorSet;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.ProductSet
{
    public class ProductsModel : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual int CategoriesId { get; set; }
        public virtual int BrandsId { get; set; } = 0;
        public virtual int ColorId { get; set; } = 0;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public bool InStock { get; set; } = false;
        public bool IsActive { get; set; } = false;
        [NotMapped]
        public string BrandName { get; set; } = string.Empty;
        [NotMapped]
        public string CategoryName { get; set; } = string.Empty;
        [NotMapped]
        public string ColorName { get; set; } = string.Empty;
        public bool IsDelete { get; set; }
        public CategoriesModel Categories { get; set; }
        public BrandModel Brands { get; set; }
        public ColorModel Color { get; set; }

    }
}
