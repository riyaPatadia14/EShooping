namespace DataAccessLayer.Interface
{
    using DataAccessLayer.Helper;
    using DataAccessLayer.Models.ProductSet;
    using DataAccessLayer.Models.ProductSet.Dto;

    public interface IProducts
    {
        Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber);
        Task AddProduct(ProductAddDto products);
        ProductViewDto GetProductsById(int id);
        Task UpdateProduct(ProductViewDto products);
        Task DeleteProduct(ProductsModel products);
    }
}