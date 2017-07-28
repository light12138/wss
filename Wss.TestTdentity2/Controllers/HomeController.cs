using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wss.TestTdentity2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Wss.TestTdentity2.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(
             SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManage
            )
        {
            _userManager = userManage;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            //var result =  _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            var user = new ApplicationUser { UserName ="wss", Email = "719955043@qq.com" };
            //var result =  _userManager.CreateAsync(user, "wzl19961017");
            //_signInManager.SignInAsync(user, isPersistent: false);
            var result =  _signInManager.PasswordSignInAsync(user.Email, "123", false, lockoutOnFailure: false);
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
