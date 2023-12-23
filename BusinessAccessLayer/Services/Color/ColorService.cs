using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Color
{
    public class ColorService : IColorService
    {
        private readonly IColor _colorRepository;
        public ColorService(IColor colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<List<SelectListItem>> GetAllColor()
        {
            return await _colorRepository.GetAllColor();
        }
    }
}
    