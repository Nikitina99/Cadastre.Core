using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDb = Cadastre.Core.DataAccess.Entities.User;
using UserDto = Cadastre.Core.Models.User;
using Cadastre.Core.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Cadastre.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Cadastre.Core.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        
        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        private AppDBContext _db;
        public AccountController(AppDBContext context)
        {
           _db = context;
        }

        [Route("LogIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserDto model)
        {
            if (ModelState.IsValid)
            {
                UserDb user = await _db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index","Client");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("~/Account/LogIn");
        }
    }
}
