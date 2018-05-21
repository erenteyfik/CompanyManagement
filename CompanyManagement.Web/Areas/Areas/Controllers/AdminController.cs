using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Data.Identity;
using CompanyManagement.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Areas.Areas.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<CMUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<CMUser>(new CMDBContext());
            userManager = new UserManager<CMUser>(userStore);
        }

        // GET: Areas/Admin
        public ActionResult Index()
        {

            return View(userManager.Users);
        }

        public ActionResult CalısanEkle(int id)
        {
            EmployeeRegister register = new EmployeeRegister()
            {
                CompanyId = id,
                Email = "teyfik@code35.net"
            };

            //var sender = new MailAddress("tevfik.eren.te@gmail.com", "Demo test");
            //var receiver = new MailAddress("tevfik.eren.te@gmail.com", "test");
            //var password = "matematik";
            //var sub = "CompanyManagment";
            //var body = "Please <a href=\"http://localhost:9585/Areas/Admin/Cal%C4%B1sanEkle/3\">login</a>";

            //var smtp = new SmtpClient()
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(sender.Address, password)
            //};

            //using (var message = new MailMessage(sender, receiver)
            //{
            //    Subject = sub,
            //    Body = body,
            //})
            //{
            //    smtp.Send(message);
            //}

                return View(register);
        }

        [HttpPost]
        public ActionResult CalısanEkle(EmployeeRegister model)
        {
            if (ModelState.IsValid)
            {
                var user = new CMUser()
                {
                    UserName = model.UserName,
                    CompanyId = model.CompanyId,
                    Email = model.Email,
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
            return View(model);
        }

        [HttpPost]
        public ActionResult CalısanPost(EmployeeRegister model)
        {
            if (ModelState.IsValid)
            {
                var user = new CMUser()
                {
                    UserName = model.UserName,
                    CompanyId = model.CompanyId,
                    Email = model.Email,
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
            return View(model);
        }

    }
}