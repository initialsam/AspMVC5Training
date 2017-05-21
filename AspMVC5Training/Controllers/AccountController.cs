using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var username = "demo1";
            var password = "ppp999";

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var creationResult = userManager.Create(new IdentityUser(username), password);
            Console.WriteLine("Creation: {0}", creationResult.Succeeded);

            //var user = userManager.FindByName(username);
            //var claimResult = userManager.AddClaim(user.Id, new Claim("given_name", "scott"));
            //Console.WriteLine("Claim Added: {0}", claimResult.Succeeded);

            //var checkPassword = userManager.CheckPassword(user, password);
            //Console.WriteLine("Password Match: {0}", checkPassword);

            return View(new AccountViewModel { Success= creationResult.Succeeded });
        }

        public class AccountViewModel
        {
            public bool Success { get; set; }
        }
    }
}