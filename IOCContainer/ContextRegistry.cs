using BusinessAccessLayer.Services.Brand;
using BusinessAccessLayer.Services.Categories;
using BusinessAccessLayer.Services.Client;
using BusinessAccessLayer.Services.Color;
using BusinessAccessLayer.Services.Products;
using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Implementations;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOCContainer
{
    public static class ContextRegistry
    {
        public static void RegisterContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EShoppingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EShoppingConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IProducts, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IBrand, BrandRepository>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IColor, ColorRepository>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IShop, ShopRepository>();
            services.AddTransient<IShopService,ShopService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                        .AddCookie(option =>
                        {
                            option.ExpireTimeSpan = TimeSpan.FromMinutes(60 * 1);
                            option.LoginPath = "/User/Login";
                            option.AccessDeniedPath = "/User/Login";
                        });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}