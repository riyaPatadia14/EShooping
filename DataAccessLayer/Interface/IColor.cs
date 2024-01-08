using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Interface
{
    public interface IColor
    {
        Task<List<SelectListItem>> GetAllColor();
    }
}
