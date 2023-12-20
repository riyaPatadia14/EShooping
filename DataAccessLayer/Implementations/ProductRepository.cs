using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ProductSet;
using DataAccessLayer.Models.ProductSet.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using DataAccessLayer.Helper;
namespace DataAccessLayer.Implementations
{
    public class ProductRepository : IProducts
    {
        private readonly IGenericRepository<ProductsModel> _genericRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly EShoppingDbContext _eShoppingDbContext;
        private readonly IBrand _brandRepository;
        private readonly IColor _colorRepository;
        private readonly ICategory _categoryRepository;

        public ProductRepository(IGenericRepository<ProductsModel> genericRepository, IHostingEnvironment hostingEnvironment, EShoppingDbContext eShoppingDbContext, IBrand brandRepository, IColor colorRepository, ICategory categoryRepository)
        {
            _eShoppingDbContext = eShoppingDbContext;
            _hostingEnvironment = hostingEnvironment;
            _genericRepository = genericRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductAddDto> ProductDropDownList(ProductAddDto products)
        {
            var productAddDto = new ProductAddDto
            {
                Categories = await _categoryRepository.GetCategoryList(),
                Brands = await _brandRepository.GetAllBrand(),
                Colors = await _colorRepository.GetAllColor(),
            };

            return productAddDto;
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
                    CategoriesId = products.CategoriesId,
                    BrandsId = products.BrandsId,
                    ColorId = products.ColorId,
                    Price = products.Price,
                    ImagePath = products.ImageFile.FileName,
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
        public async Task DeleteProduct(ProductViewDto products)
        {
            products.IsDelete = true;
            var deleteProduct = new ProductsModel
            {
                IsDelete = products.IsDelete,
            };
            await _genericRepository.Update(deleteProduct);
        }
        public async Task<PaginatedList<ProductListDto>> GetAllProducts(int? pageNumber)
        {
            try
            {
                var allProducts = await _genericRepository.GetAll();
                var productList = (from product in _eShoppingDbContext.Products
                                   join color in _eShoppingDbContext.Colors on product.ColorId equals color.Id
                                   join brand in _eShoppingDbContext.Brands on product.BrandsId equals brand.Id
                                   join category in _eShoppingDbContext.Categories on product.CategoriesId equals category.Id
                                   select new ProductListDto
                                   {
                                       Id = product.Id,
                                       Title = product.Title,
                                       Description = product.Description,
                                       Price = product.Price,
                                       CategoryId = product.CategoriesId,
                                       BrandId = product.BrandsId,
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
        public async Task<ProductViewDto> GetProductsById(int id)
        {
            try
            {
                var productById = _genericRepository.GetbyId(id);
                var productView = new ProductViewDto()
                {
                    Categories = await _categoryRepository.GetCategoryList(),
                    Brands = await _brandRepository.GetAllBrand(),
                    Colors = await _colorRepository.GetAllColor(),
                    Id = id,
                    Title = productById.Title,
                    Description = productById.Description,
                    IsActive = productById.IsActive,
                    InStock = productById.InStock,
                    BrandsId = productById.BrandsId,
                    CategoriesId = productById.CategoriesId,
                    ColorId = productById.ColorId,
                    CategoryName = productById.CategoryName,
                    BrandName = productById.BrandName,
                    ColorName = productById.ColorName,
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
                var productId = await GetProductsById(products.Id);
                if (productId != null)
                {
                    var productUpdate = new ProductsModel()
                    {
                        Id = products.Id,
                        Title = products.Title,
                        Description = products.Description,
                        InStock = products.InStock,
                        CategoriesId = products.CategoriesId,
                        BrandsId = products.BrandsId,
                        ColorId = products.ColorId,
                        Price = products.Price,
                        ImagePath = products.ImageFile != null ? products.ImageFile.FileName : productId.ImagePath,
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
