using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Security.Claims;

namespace Project.Controllers
{
    public class UsersController : Controller
    {
        private readonly IConfiguration configuration;
        UsersDAL usersdal;
        public UsersController(IConfiguration configuration)
        {
            this.configuration = configuration;
            usersdal = new UsersDAL(configuration);
        }
        // GET: UsersController
        public IActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        public IActionResult Register(Users users)
        {
            try
            {
                int res = usersdal.UsersRegister(users);
                if (res == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(Users users)
        {
            Users user = usersdal.UsersLogin(users);
             
           // HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            HttpContext.Session.SetInt32("userid", users.Userid);
            HttpContext.Session.SetString("emailid", users.Email);
           
            HttpContext.Session.SetInt32("roleid", users.Roleid);

            if (user != null)
            {
                if (user.Roleid == 1)
                {
                    return RedirectToAction("Create", "Product");
                }
                else if (user.Roleid == 2)
                {
                    return RedirectToAction("List", "Product");
                }
                return View();
            }
            return View();
        }
        // POST: UsersController/Delete/5
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            var StoredCookies = Request.Cookies.Keys;
            foreach (var Cookie in StoredCookies)
            {
                Response.Cookies.Delete(Cookie);
            }
            return RedirectToAction("Login");
        }
    }
}
