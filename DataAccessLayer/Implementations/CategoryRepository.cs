using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class CategoryRepository : ICategory
    {
        private readonly IGenericRepository<CategoriesModel> _genericRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly EShoppingDbContext _eShoppingDbContext;
        public CategoryRepository(IGenericRepository<CategoriesModel> genericRepository, IHostingEnvironment hostingEnvironment, EShoppingDbContext eShoppingDbContext)
        {
            _genericRepository = genericRepository;
            _hostingEnvironment = hostingEnvironment;
            _eShoppingDbContext = eShoppingDbContext;
        }
        public async Task AddCategory(CategoryAddDto category)
        {
            try
            {
                var path = _hostingEnvironment.WebRootPath;
                var filePath = "img/category-img/" + category.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(category.ImagePath, fullPath);
                var categoryAdd = new CategoriesModel
                {
                    CategoryName = category.CategoryName,
                    ImagePath = category.ImagePath.FileName,
                    Active = category.Active,
                };

                await _genericRepository.Add(categoryAdd);
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
        public async Task DeleteCategory(CategoriesModel category)
        {
            try
            {
                await _genericRepository.Update(category);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PaginatedList<CategoryListDto>> GetAllCategories(int? pageNumber)
        {
            try
            {
                var category = await _genericRepository.GetAll();
                var categoryList = category
               .Select(x => new CategoryListDto()
               {
                   Id = x.Id,
                   CategoryName = x.CategoryName,
                   ImagePath = x.ImagePath,
                   Active = x.Active
               }).ToList();
                int pageSize = 10;
                return await PaginatedList<CategoryListDto>.CreateAsync(categoryList, pageNumber ?? 1, pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CategoryViewDto GetCategoryById(int id)
        {
            try
            {
                var categoryById = _genericRepository.GetbyId(id);
                var categoryView = new CategoryViewDto()
                {
                    Id = id,
                    CategoryName = categoryById.CategoryName,
                    ImagePath = categoryById.ImagePath,
                    Active = categoryById.Active
                };
                return categoryView;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateCategory(CategoryViewDto category)
        {
            try
            {
                var categoryId = _genericRepository.GetbyId(category.Id);
                if (categoryId != null)
                {
                    var categoryUpdate = new CategoriesModel()
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName,
                        ImagePath = category.ImageFile.FileName,
                        Active = category.Active
                    };
                    await _genericRepository.Update(categoryUpdate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}