using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AspMVC5Training.Models;
using AspMVC5Training.App_Start;

namespace AspMVC5Training
{
	public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {
            // 設定資料庫內容、使用者管理員和登入管理員，以針對每個要求使用單一執行個體
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // 讓應用程式使用 Cookie 儲存已登入使用者的資訊
            // 並使用 Cookie 暫時儲存使用者利用協力廠商登入提供者登入的相關資訊；
            // 在 Cookie 中設定簽章
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // 讓應用程式在使用者登入時驗證安全性戳記。
                    // 這是您變更密碼或將外部登入新增至帳戶時所使用的安全性功能。  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });


        }
        //public void Configuration(IAppBuilder app)
        //{
        //    app.CreatePerOwinContext(() => new IdentityDbContext("DefaultConnection"));
        //    app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));
        //    app.CreatePerOwinContext<UserManager<IdentityUser>>(
        //        (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));
        //    app.CreatePerOwinContext<SignInManager<IdentityUser, string>>(
        //        (opt, cont) =>
        //            new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));

        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
        //    });
        //}
    }
}