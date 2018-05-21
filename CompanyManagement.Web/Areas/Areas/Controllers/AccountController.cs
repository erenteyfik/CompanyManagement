using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Data.Identity;
using CompanyManagement.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Areas.Areas.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<CMUser> userManager;

        public AccountController()
        {
            var userStore = new UserStore<CMUser>(new CMDBContext());
            userManager = new UserManager<CMUser>(userStore);
            //register
            //parola oluştururken istedigimiz özellikleri ekledik extra custompasswordvalidatora ekledik
            userManager.PasswordValidator = new UserPasswordValidator()
            {
                //RequireDigit = true,
                //RequiredLength = 6,
                //RequireLowercase = true,
                //RequireUppercase = true,
                //RequireNonLetterOrDigit = true
            };

            //register
            //aynı email adresiyle kaydı önledik +  Alphanumeric deger içermesi gerekiyor emailde '@' gibi
            userManager.UserValidator = new UserValidator<CMUser>(userManager)
            {
                //RequireUniqueEmail = true,
                //AllowOnlyAlphanumericUserNames = true
            };
        }

        // GET: Account
        public ActionResult Index()
        {
            return View(userManager.Users);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new CMUser()
                {
                     UserName = model.UserName,
                     Company = new Company()
                     {
                          Name = model.CompanyName,
                     },
                };

                var result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı başarılı şekilde oluşturulmuş ise login sayfasına gönderebiliriz.
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            //kullanıcı modelstate.ısvalid false gelse bile doldurdugu özellikler Viev(model) sayesinde register.htmlde gözükecek
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //get ten posta returnUrl taşımış olduk. input ' la
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Yalnış kullanıcı adı veya parola girdiniz.");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true //@model.rememberbe
                    };

                    authManager.SignOut(); // daha önce bir kullanıcı varsa
                    authManager.SignIn(authProperties, identity);

                    if (returnUrl == "")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {   
                        return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
                    }

                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult Delete(string id)
        {
            var user = userManager.FindById(id);

            if (user != null)
            {
                var result = userManager.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Kullanıcılar", "Admin");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "User Bulunamadı" });
            }
        }
    }
}