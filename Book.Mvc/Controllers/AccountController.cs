using Book.Mvc.Identity;
using Book.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<BooksUser> UserManager;
        private RoleManager<BooksRole> RoleManager;

        public AccountController()
        {
            UserStore<BooksUser> userStore = new UserStore<BooksUser>(new IdentityDataContext());

            UserManager = new UserManager<BooksUser>(userStore);

            var roleStore = new RoleStore<BooksRole>(new IdentityDataContext());

            RoleManager = new RoleManager<BooksRole>(roleStore);
        }

        
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                BooksUser user = new BooksUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.EMail;
                user.UserName = model.UserName;

               IdentityResult result= UserManager.Create(user,model.Password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "Kayıt işlemi başarılı olmadı");
                }
            }
            
            return View();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user=UserManager.Find(model.UserName, model.Password);

                if (user!=null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");


                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.Rememberme;

                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Kayıt Bulunamadı");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");

        }
    }
}