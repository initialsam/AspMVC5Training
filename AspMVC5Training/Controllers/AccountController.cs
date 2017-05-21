﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AspMVC5Training.Models;
using AspMVC5Training.App_Start;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using AspMVC5Training.ViewModel;

namespace AspMVC5Training.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext()
                                                    .Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext()
                                                  .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountController(
            ApplicationUserManager userManager, 
            ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Account");
                }
                
                AddErrors(result);
            }

            // 如果執行到這裡，發生某項失敗，則重新顯示表單
            return View(model);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Account
        public ActionResult Index()
        {
            //var username = "demo";
            //var password = "ppp999";

            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);

            //var creationResult = userManager.Create(new IdentityUser(username), password);
            //Console.WriteLine("Creation: {0}", creationResult.Succeeded);

            //var user = userManager.FindByName(username);
            //var claimResult = userManager.AddClaim(user.Id, new Claim("NickName", "DD"));
            //Console.WriteLine("Claim Added: {0}", claimResult.Succeeded);

            //var checkPassword = userManager.CheckPassword(user, password);
            //Console.WriteLine("Password Match: {0}", checkPassword);

            //return View(new AccountViewModel
            //{
            //    CreateUserSuccess = creationResult.Succeeded,
            //    AddClaimSuccess = claimResult.Succeeded,
            //    CheckPasswordSuccess = checkPassword
            //});
            return View();
        }

        public class AccountViewModel
        {
            public bool CreateUserSuccess { get; set; }
            public bool AddClaimSuccess { get; set; }
            public bool CheckPasswordSuccess { get; set; }

        }

       

      
    }
}