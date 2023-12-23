using DataAccessLayer.Models.BrandSet;
using DataAccessLayer.Models.CategorySet;
using DataAccessLayer.Models.ColorSet;
using DataAccessLayer.Models.OrderDetailsSet;
using DataAccessLayer.Models.OrdersSet;
using DataAccessLayer.Models.ProductSet;
using DataAccessLayer.Models.UserSet;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class EShoppingDbContext : DbContext
    {
        public EShoppingDbContext(DbContextOptions<EShoppingDbContext> options) : base (options) { }

        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<ColorModel> Colors { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<UsersModel> Users { get; set; }
    }
}
