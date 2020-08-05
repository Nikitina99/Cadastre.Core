using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cadastre.Core.Controllers
{
    public class HomeController : Controller
    {
        //Атрибут Authorize предотвращает неаутентифицированный доступ к методу Login
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name); 
        }
    }
}
