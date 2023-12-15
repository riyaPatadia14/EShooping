using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProducts _productRepository;
        public ProductService(IProducts productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<ProductsModel>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public ProductsModel GetProductsById(int id)
        {
            return _productRepository.GetProductsById(id);
        }

        public async Task ProductAdd(ProductsModel products)
        {
            await _productRepository.AddProduct(products);
        }

        public async Task ProductUpdate(ProductsModel products)
        {
            await _productRepository.UpdateProduct(products);
        }
    }
}
