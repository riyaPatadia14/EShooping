using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.ColorSet;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Implementations
{
    public class ColorRepository : IColor
    {
        private readonly IGenericRepository<ColorModel> _genericRepository;
        public ColorRepository(IGenericRepository<ColorModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<SelectListItem>> GetAllColor()
        {
            var getAllColor = await _genericRepository.GetAll();
            var colorList = getAllColor
               .Select(x => new SelectListItem()
               {
                   Value = x.Id.ToString(),
                   Text = x.ColorName,
               }).ToList();
            return colorList;
        }
    }
}
