using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.ProductSet.Dto
{
    public class ProductAddDto 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoriesId { get; set; }
        [Required(ErrorMessage = "Please Select Brand")]
        public int BrandsId { get; set; } = 0;
        [Required(ErrorMessage = "Please Select Color")]
        public int ColorId { get; set; } = 0;
        [Required(ErrorMessage = "Please Enter Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Enter Image")]
        public string ImagePath { get; set; } = string.Empty;
        public bool InStock { get; set; } = false;
        public bool IsActive { get; set; } = false;
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string BrandName { get; set; } = string.Empty;
        [NotMapped]
        public string CategoryName { get; set; } = string.Empty;
        [NotMapped]
        public string ColorName { get; set; } = string.Empty;
        public bool IsDelete { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Brands { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Colors { get; set; } = new List<SelectListItem>();
    }
}


