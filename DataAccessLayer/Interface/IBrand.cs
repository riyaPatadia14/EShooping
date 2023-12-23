using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccessLayer.Interface
{
    public interface IBrand
    {
        Task<List<SelectListItem>> GetAllBrand();
    }
}
