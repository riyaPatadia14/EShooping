using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ClientSet;
using DataAccessLayer.Models.ProductSet;

namespace DataAccessLayer.Implementations
{
    public class ClientRepository : IClient
    {
        private readonly IGenericRepository<ProductsModel> _genericRepository;
        private readonly EShoppingDbContext _eShoppingDbContext;
        private readonly IBrand _brandRepository;
        private readonly IColor _colorRepository;
        private readonly ICategory _categoryRepository;

        public ClientRepository(IGenericRepository<ProductsModel> genericRepository, EShoppingDbContext eShoppingDbContext, IBrand brandRepository, IColor colorRepository, ICategory categoryRepository)
        {
            _eShoppingDbContext = eShoppingDbContext;
            _genericRepository = genericRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<PaginatedList<ClientProductListDto>> GetClientProductList(int? pageNumber)
        {
            try
            {
                await _genericRepository.GetAll();
                var productList = (from product in _eShoppingDbContext.Products
                                   join color in _eShoppingDbContext.Colors on product.ColorId equals color.Id
                                   join brand in _eShoppingDbContext.Brands on product.BrandsId equals brand.Id
                                   join category in _eShoppingDbContext.Categories on product.CategoriesId equals category.Id
                                   select new ClientProductListDto
                                   {
                                       Id = product.Id,
                                       Title = product.Title,
                                       Description = product.Description,
                                       Price = product.Price,
                                       CategoriesId = product.CategoriesId,
                                       BrandsId = product.BrandsId,
                                       ColorId = product.ColorId,
                                       IsActive = product.IsActive,
                                       InStock = product.InStock,
                                       ImagePath = product.ImagePath,
                                       BrandName = brand.BrandName,
                                       CategoryName = category.CategoryName,
                                       ColorName = color.ColorName
                                   }).ToList<ClientProductListDto>();
                int pageSize = 6;
                return await PaginatedList<ClientProductListDto>.CreateAsync(productList, pageNumber ?? 1, pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ClientProductViewDto> GetClientProductsById(int id)
        {
            try
            {
                var productById = _genericRepository.GetbyId(id);
                var productView = new ClientProductViewDto()
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
    }
}