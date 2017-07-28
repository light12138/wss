using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Wss.TestIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;



        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = UserManager;
        }

        public IActionResult Index()
        {
            var user = new ApplicationUser { UserName = "wss", Email ="719955043@qq.com" };
            var result = _userManager.CreateAsync(user,"123");
            return View();
        }



        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
