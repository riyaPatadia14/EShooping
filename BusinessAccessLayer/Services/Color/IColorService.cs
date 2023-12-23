using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessAccessLayer.Services.Color
{
    public interface IColorService
    {
        Task<List<SelectListItem>> GetAllColor();
    }
}
