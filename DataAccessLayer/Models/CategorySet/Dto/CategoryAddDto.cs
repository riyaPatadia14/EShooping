using DataAccessLayer.Models.ProductSet;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.CategorySet.Dto
{
    public class CategoryAddDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImagePath { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        [NotMapped]
        public List<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}