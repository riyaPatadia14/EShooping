using DataAccessLayer.Models.ProductSet;

namespace BusinessAccessLayer.Services.Products
{
    public interface IProductService
    {
        Task ProductAdd(ProductsModel products);
        Task ProductUpdate(ProductsModel products);
        ProductsModel GetProductsById(int id);
        Task<IList<ProductsModel>> GetAllProducts();
    }
}
