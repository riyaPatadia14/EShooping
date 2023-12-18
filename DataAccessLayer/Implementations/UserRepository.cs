using DataAccessLayer.Data;
using DataAccessLayer.GenericRepo;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.UserSet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DataAccessLayer.Implementations
{
    public class UserRepository : IUser
    {
        private readonly EShoppingDbContext _eShoppingDbContext;
        private readonly GenericRepository<UsersModel> _genericRepository;
        public UserRepository(EShoppingDbContext eShoppingDbContext, GenericRepository<UsersModel> genericRepository)
        {
            _eShoppingDbContext = eShoppingDbContext;
            _genericRepository = genericRepository;
        }
        //public Task AdminUser(UsersModel user)
        //{
        //    var data = _eShoppingDbContext.User.Where(x => x.Email == user.Email && x.Password == user.Password).SingleOrDefault();
        //    if (data != null && data.IsAdmin == true)
        //    {
        //        bool isValid = (data.Email == user.Email && data.Password == user.Password && user.IsAdmin == user.IsAdmin);
        //        if (isValid)
        //        {
        //            var identity = new ClaimsIdentity(new[] { Claim(ClaimTypes.Name, user.Email) },
        //                CookieAuthenticationDefaults.AuthenticationScheme);
        //            var principal = new ClaimsPrincipal(identity);
        //            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //        }
        //    }
        //    else
        //    {

        //    }
        //    return ;
        //}
    }
}
