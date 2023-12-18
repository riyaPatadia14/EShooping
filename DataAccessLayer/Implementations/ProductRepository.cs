using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using DataAccessLayer.Helper;
using DataAccessLayer.Models.CategorySet.Dto;
using DataAccessLayer.Models.CategorySet;
using System.Drawing;

namespace DataAccessLayer.Implementations
{
    public class ProductRepository : IProducts
    {
        private readonly IGenericRepository<ProductsModel> _genericRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly EShoppingDbContext _eShoppingDbContext;

        public ProductRepository(IGenericRepository<ProductsModel> genericRepository, IHostingEnvironment hostingEnvironment, EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext = eShoppingDbContext;
            _hostingEnvironment = hostingEnvironment;
            _genericRepository = genericRepository;
        }

        public async Task AddProduct(ProductAddDto products)
        {
            try
            {
                var path = _hostingEnvironment.WebRootPath;
                var filePath = "img/category-img/" + products.ImageFile.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(products.ImageFile, fullPath);
                var productAdd = new ProductsModel
                {
                    Title = products.Title,
                    Description = products.Description,
                    CategoryId = products.CategoryId,
                    BrandId = products.BrandId,
                    ColorId = products.ColorId,
                    Price = products.Price,
                    ImagePath = products.ImagePath,
                    InStock = products.InStock,
                    IsActive = products.IsActive,
                };

                await _genericRepository.Add(productAdd);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UploadFile(IFormFile file, string path)
        {
            try
            {
                FileStream stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
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
        public async Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber)
        {
            try
            {
                var allProducts = await _genericRepository.GetAll();
                var productList = (from product in _eShoppingDbContext.Products
                                   join color in _eShoppingDbContext.Colors on product.ColorId equals color.Id
                                   join brand in _eShoppingDbContext.Brands on product.BrandId equals brand.Id
                                   join category in _eShoppingDbContext.Categories on product.CategoryId equals category.Id
                                   select new ProductListDto
                                   {
                                       Id = product.Id,
                                       Title = product.Title,
                                       Description = product.Description,
                                       Price = product.Price,
                                       CategoryId = product.CategoryId,
                                       BrandId = product.BrandId,
                                       ColorId = product.ColorId,
                                       IsActive = product.IsActive,
                                       InStock = product.InStock,
                                       ImagePath = product.ImagePath,
                                       BrandName = brand.BrandName,
                                       CategoryName = category.CategoryName,
                                       ColorName = color.ColorName
                                   }).ToList<ProductListDto>();
                int pageSize = 10;
                return await PaginatedList<ProductListDto>.CreateAsync(productList, pageNumber ?? 1, pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ProductViewDto GetProductsById(int id)
        {
            try
            {
                var productById = _genericRepository.GetbyId(id);
                var productView = new ProductViewDto()
                {
                    Id = id,
                    Title = productById.Title,
                    Description = productById.Description,
                    IsActive = productById.IsActive,
                    InStock = productById.InStock,
                    CategoryId = productById.CategoryId,
                    BrandId = productById.BrandId,
                    ColorId = productById.ColorId,
                    Price = productById.Price,
                    ImagePath = productById.ImagePath,
                };
                return productView;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateProduct(ProductViewDto products)
        {
            try
            {
                var productId = _genericRepository.GetbyId(products.Id);
                if (productId != null)
                {
                    var productList = (from product in _eShoppingDbContext.Products
                                       join color in _eShoppingDbContext.Colors on product.ColorId equals color.Id
                                       join brand in _eShoppingDbContext.Brands on product.BrandId equals brand.Id
                                       join category in _eShoppingDbContext.Categories on product.CategoryId equals category.Id
                                       where product.Id == products.Id
                                       select new ProductViewDto
                                       {
                                           Id = product.Id,
                                           Title = product.Title,
                                           Description = product.Description,
                                           Price = product.Price,
                                           CategoryId = product.CategoryId,
                                           BrandId = product.BrandId,
                                           ColorId = product.ColorId,
                                           IsActive = product.IsActive,
                                           InStock = product.InStock,
                                           ImagePath = product.ImagePath,
                                           BrandName = brand.BrandName,
                                           CategoryName = category.CategoryName,
                                           ColorName = color.ColorName
                                       }).ToList<ProductViewDto>();

                    var productUpdate = new ProductsModel()
                    {
                        Id = products.Id,
                        Title = products.Title,
                        Description = products.Description,
                        InStock = products.InStock,
                        CategoryId = products.CategoryId,
                        BrandId = products.BrandId,
                        ColorId = products.ColorId,
                        Price = products.Price,
                        ImagePath = products.ImageFile.FileName,
                        IsActive = products.IsActive
                    };
                    await _genericRepository.Update(productUpdate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
