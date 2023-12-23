using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Brand
{
    public class BrandService : IBrandService
    {
        private readonly IBrand _brandRepository;
        public BrandService(IBrand brandRepository)
        {
            _brandRepository= brandRepository;
        }
        public async Task<List<SelectListItem>> GetAllBrandList()
        {
            return await _brandRepository.GetAllBrand();
        }
    }
}
