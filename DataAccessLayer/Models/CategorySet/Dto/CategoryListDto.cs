﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.CategorySet.Dto
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile ImageFile { get; set; } 
        public bool Active { get; set; }
    }
}