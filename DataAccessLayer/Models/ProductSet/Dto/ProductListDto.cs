﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.ProductSet.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual int CategoryId { get; set; } = 0;
        public virtual int BrandId { get; set; } = 0;
        public virtual int ColorId { get; set; } = 0;
        public decimal Price { get; set; } = 0;
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
        [NotMapped]
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> Brands { get; set; } = new List<SelectListItem>();
        [NotMapped]
        public List<SelectListItem> Colors { get; set; } = new List<SelectListItem>();
    }
}


