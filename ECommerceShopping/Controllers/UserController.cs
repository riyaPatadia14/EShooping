using DataAccessLayer.Data;
using DataAccessLayer.Models.UserSet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceShopping.Controllers
{
    public class UserController : Controller
    {
        private readonly EShoppingDbContext _eShoppingDbContext;
        public UserController(EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext = eShoppingDbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UsersModel user)
        {
            try
            {
                var data = _eShoppingDbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).SingleOrDefault();
                if (data != null && data.IsAdmin == true)
                {
                    bool isValid = (data.Email == user.Email && data.Password == user.Password);
                    if (isValid)
                    {

                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Email) }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Name", data.FirstName + data.LastName);
                        HttpContext.Session.SetString("Email", user.Email);
                        HttpContext.Session.SetString("Password", user.Password);
                        return RedirectToAction("Index", "Category");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Invalid Email";
                    TempData["errorMessage"] = "Invalid Password";
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [AcceptVerbs("Post", "Get")]
        public IActionResult LogOut()
        {
            try
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var storedCookies = Request.Cookies.Keys;
                foreach (var cookies in storedCookies)
                {
                    Response.Cookies.Delete(cookies);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
