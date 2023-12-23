using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Brand
{
    public interface IBrandService
    {
        Task<List<SelectListItem>> GetAllBrandList();
    }
}
