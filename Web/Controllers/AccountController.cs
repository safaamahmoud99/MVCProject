using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        AccountAppService accountAppService = new AccountAppService();

        public ActionResult Register() => View(new RegisterViewodel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewodel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            IdentityResult result = accountAppService.Register(user);
            if (result.Succeeded)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIDentity, string> signinmanager =
                    new SignInManager<ApplicationUserIDentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                var identityUser = accountAppService.Find(user.UserName, user.PasswordHash);
                signinmanager.SignIn(identityUser, true, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(user);
            }
        }
        public ActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            ApplicationUserIDentity identityUser = accountAppService.Find(user.UserName, user.PasswordHash);

            if (identityUser != null)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIDentity, string> signinmanager =
                    new SignInManager<ApplicationUserIDentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                signinmanager.SignIn(identityUser, true, true);
                if (accountAppService.HasRole(identityUser.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username OR Password");
                return View(user);
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

    }
}