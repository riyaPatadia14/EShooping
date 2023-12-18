using DataAccessLayer.Models.ProductSet;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace DataAccessLayer.Models.CategorySet
{
    public class CategoriesModel : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public ICollection<ProductsModel> Products { get; set; }
    }
}
