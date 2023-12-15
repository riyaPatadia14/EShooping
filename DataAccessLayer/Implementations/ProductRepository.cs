using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet;

namespace DataAccessLayer.Implementations
{
    public class ProductRepository : IProducts
    {
        private readonly IGenericRepository<ProductsModel> _genericRepository;

        public ProductRepository(IGenericRepository<ProductsModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }

        public Task AddProduct(ProductsModel products)
        {
            try
            {
                return _genericRepository.Add(products);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task DeleteProduct(ProductsModel products)
        {
            return _genericRepository.Delete(products);
        }

        public async Task<IList<ProductsModel>> GetAllProducts()
        {
           return await _genericRepository.GetAll();
        }

        public ProductsModel GetProductsById(int id)
        {
            return _genericRepository.GetbyId(id);
        }

        public async Task UpdateProduct(ProductsModel products)
        {
           await _genericRepository.Update(products);
        }
    }
}
