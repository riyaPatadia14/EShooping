using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.ProductSet.Dto
{
    public class ProductAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoriesId { get; set; }
        public int BrandsId { get; set; } = 0;
        public int ColorId { get; set; } = 0;
        public decimal Price { get; set; }
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


