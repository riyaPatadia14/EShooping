using DataAccessLayer.Models.ProductSet;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccessLayer.Models.ClientSet
{
    public class ClientOrderListDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public bool IsDelete { get; set; }
        [NotMapped]
        public List<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}
