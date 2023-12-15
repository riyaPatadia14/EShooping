using DataAccessLayer.Models.ProductSet;

namespace DataAccessLayer.Models.ColorSet
{
    public class ColorModel
    {
        public int Id { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ICollection<ProductsModel> Products { get; set; }
    }
}
