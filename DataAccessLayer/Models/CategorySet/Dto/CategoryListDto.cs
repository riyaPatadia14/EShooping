using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.CategorySet.Dto
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImageFile { get; set; } 
        public bool Active { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
