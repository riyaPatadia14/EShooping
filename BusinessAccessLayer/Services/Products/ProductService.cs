using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet.Dto;

namespace BusinessAccessLayer.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProducts _productRepository;
        public ProductService(IProducts productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber)
        {
            return await _productRepository.GetAllProducts(pageNumber);
        }
        public ProductViewDto GetProductsById(int id)
        {
            return _productRepository.GetProductsById(id);
        }
        public async Task ProductAdd(ProductAddDto products)
        {
            await _productRepository.AddProduct(products);
        }
        public async Task ProductUpdate(ProductViewDto products)
        {
            await _productRepository.UpdateProduct(products);
        }
    }
}