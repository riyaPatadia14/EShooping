using BusinessAccessLayer.Services.Categories;
using BusinessAccessLayer.Services.Products;
using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOCContainer
{
    public static class ContextRegistry
    {
        public static void RegisterContainer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<EShoppingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EShoppingConnection")));
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IProducts, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<ICategory, CategoryRepository>();
            service.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
