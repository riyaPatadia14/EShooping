namespace DataAccessLayer.Interface
{
    using DataAccessLayer.Helper;
    using DataAccessLayer.Models.ProductSet.Dto;

    public interface IProducts
    {
        Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber);
        Task AddProduct(ProductAddDto products);
        Task<ProductViewDto> GetProductsById(int id);
        Task UpdateProduct(ProductViewDto products);
        Task DeleteProduct(ProductViewDto products);
        Task<ProductAddDto> ProductDropDownList(ProductAddDto products);
    }
}