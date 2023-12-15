namespace DataAccessLayer.Interface
{
    using DataAccessLayer.Models.ProductSet;

    public interface IProducts
    {
        Task<IList<ProductsModel>> GetAllProducts();
        Task AddProduct(ProductsModel products);
        ProductsModel GetProductsById(int id);
        Task UpdateProduct(ProductsModel products);
        Task DeleteProduct(ProductsModel products);
    }
}