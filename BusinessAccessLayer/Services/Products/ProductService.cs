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
            try
            {
                _productRepository = productRepository;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber, string searchString)
        {
            try
            {
                return await _productRepository.GetAllProducts(pageNumber, searchString);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<ProductViewDto> GetProductsById(int id)
        {
            try
            {
                return _productRepository.GetProductsById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task ProductAdd(ProductAddDto products)
        {
            try
            {
                await _productRepository.AddProduct(products);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ProductDelete(ProductViewDto products)
        {
            try
            {
                await _productRepository.DeleteProduct(products);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductAddDto> ProductDropDown(ProductAddDto products)
        {
            try
            {
                return await _productRepository.ProductDropDownList(products);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ProductUpdate(ProductViewDto products)
        {
            try
            {
                await _productRepository.UpdateProduct(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

