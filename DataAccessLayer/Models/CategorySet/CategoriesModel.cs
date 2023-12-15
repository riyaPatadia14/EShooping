using DataAccessLayer.Models.ProductSet;
using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.Models.CategorySet
{
    public class CategoriesModel : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public bool Active { get; set; } 
        public ICollection<ProductsModel> Products { get; set; }
    }
}
