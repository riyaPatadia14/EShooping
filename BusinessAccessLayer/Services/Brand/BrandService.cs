using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Brand
{
    public class BrandService : IBrandService
    {
        private readonly IBrand _brandRepository;
        public BrandService(IBrand brandRepository)
        {
            try
            {
                _brandRepository = brandRepository;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<SelectListItem>> GetAllBrandList()
        {
            try
            {
                return await _brandRepository.GetAllBrand();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
