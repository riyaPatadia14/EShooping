using DataAccessLayer.Models.ProductSet;

namespace DataAccessLayer.Models.BrandSet
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}
