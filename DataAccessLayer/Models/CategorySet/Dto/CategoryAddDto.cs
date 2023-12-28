using DataAccessLayer.Models.ProductSet;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.CategorySet.Dto
{
    public class CategoryAddDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        [NotMapped]
        [Required(ErrorMessage = "Please Enter Image")]
        public IFormFile ImagePath { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        [NotMapped]
        public List<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}