using DataAccessLayer.Models.ProductSet;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.CategorySet
{
    public class CategoriesModel : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDelete { get; set; }
        public ICollection<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}

