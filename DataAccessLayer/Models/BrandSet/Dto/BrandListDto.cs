﻿using DataAccessLayer.Models.ProductSet;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.BrandSet.Dto
{
    public class BrandListDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [NotMapped]
        public List<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}
