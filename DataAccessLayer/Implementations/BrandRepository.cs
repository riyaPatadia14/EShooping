using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.BrandSet;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Implementations
{
    public class BrandRepository : IBrand
    {
        private readonly IGenericRepository<BrandModel> _genericRepository;
        public BrandRepository(IGenericRepository<BrandModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<SelectListItem>> GetAllBrand()
        {
            var getAllBrand = await _genericRepository.GetAll();
            var brandList = getAllBrand.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrandName
            }).ToList();
            return brandList;
        }
    }
}
