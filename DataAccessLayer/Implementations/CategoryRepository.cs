using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Helper;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.CategorySet.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Implementations
{
    public class CategoryRepository : ICategory
    {
        private readonly IGenericRepository<CategoriesModel> _genericRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CategoryRepository(IGenericRepository<CategoriesModel> genericRepository, IHostingEnvironment hostingEnvironment)
        {
            _genericRepository = genericRepository;
            _hostingEnvironment = hostingEnvironment;
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
                    IsActive = category.Active,
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
        public async Task<PaginatedList<CategoryListDto>> GetAllCategories(int? pageNumber, string searchString)
        {
            try
            {
                var category = await _genericRepository.GetAll();
                var categoryList = category
                .Where(x => x.IsDelete == false)
               .Select(x => new CategoryListDto()
               {
                   Id = x.Id,
                   CategoryName = x.CategoryName,
                   ImagePath = x.ImagePath,
                   Active = x.IsActive,
                   IsDelete = x.IsDelete,
               }).ToList();
                int pageSize = 4;
                if (!String.IsNullOrEmpty(searchString))
                {
                    categoryList = categoryList.Where(p =>
                        p.CategoryName.Contains(searchString) 
                    ).ToList();
                }
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
                    Active = categoryById.IsActive
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
                if (category.ImageFile != null)
                {
                    var path = _hostingEnvironment.WebRootPath;
                    var filePath = "img/category-img/" + category.ImageFile.FileName;
                    var fullPath = Path.Combine(path, filePath);
                    UploadFile(category.ImageFile, fullPath);
                    if (categoryId != null)
                    {
                        var categoryUpdate = new CategoriesModel()
                        {
                            Id = category.Id,
                            CategoryName = category.CategoryName,
                            ImagePath = category.ImageFile.FileName,
                            IsActive = category.Active
                        };
                        await _genericRepository.Update(categoryUpdate);
                    }
                }
                else
                {
                    if (categoryId != null)
                    {
                        var categoryUpdate = new CategoriesModel()
                        {
                            Id = category.Id,
                            CategoryName = category.CategoryName,
                            ImagePath = category.ImagePath,
                            IsActive = category.Active
                        };
                        await _genericRepository.Update(categoryUpdate);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<SelectListItem>> GetCategoryList()
        {
            try
            {
                var category = await _genericRepository.GetAll();
                var categoryList = category
               .Where(x => x.IsDelete == false)
               .Select(x => new SelectListItem()
               {
                   Value = x.Id.ToString(),
                   Text = x.CategoryName,
               }).ToList();

                return categoryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteCategory(CategoryViewDto category)
        {
            category.IsDelete = true;
            var deleteCatgory = new CategoriesModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                ImagePath = category.ImagePath,
                IsActive = category.Active,
                IsDelete = category.IsDelete,
            };
            await _genericRepository.Update(deleteCatgory);

        }
    }
}