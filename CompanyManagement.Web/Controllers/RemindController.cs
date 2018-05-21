using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class RemindController : Controller
    {
        private CMDBContext db = new CMDBContext();

        // GET: Remind
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;
            var remind = db.Reminds.OrderByDescending(o => o.CreateTime).ToPagedList<Remind>(_pageNo, 11);

            return View(remind);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Remind model)
        {
            var remind = new Remind()
            {
                Description = model.Description,
                CreateTime = DateTime.Now,
                Title = model.Title,
                WhoUser = "Mahmut",
                UploadTime = model.UploadTime,
            };
            db.Reminds.Add(remind);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CRCreate(int id)
        {
            Remind remind = new Remind()
            {
                WhoUser = "Mahmut",
                CustomerId = id,
            };


            return View(remind);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CRCreate(CustomerDetailModel model)
        {
            Remind remind = new Remind()
            {
                CustomerId = model.customer.Id,
                Description = model.remind.Description,
                CreateTime = DateTime.Now,
                Title = model.remind.Title,
                WhoUser = "Mahmut",
            };
            db.Reminds.Add(remind);
            db.SaveChanges();
            return RedirectToAction("Detail", "Customer", new { id = model.customer.Id });
        }


        public ActionResult PRCreate(int id)
        {
            Remind remind = new Remind()
            {
                WhoUser = "Mahmut",
                ProjectId = id,
            };


            return View(remind);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PRCreate(ProjectDetailModel model)
        {
            Remind remind = new Remind()
            {
                ProjectId = model.project.Id,
                Description = model.remind.Description,
                CreateTime = DateTime.Now,
                Title = model.remind.Title,
                WhoUser = "Mahmut",
            };
            db.Reminds.Add(remind);
            db.SaveChanges();

            return RedirectToAction("Detail", "Project", new { id = model.project.Id });
        }

        public ActionResult Detail(int id)
        {
            var remind = db.Reminds.FirstOrDefault(f => f.Id == id);
            return View(remind);
        }

        public ActionResult Delete(int id)
        {
            var remind = db.Reminds.Find(id);

            if (remind != null)
            {
                var result = db.Reminds.Remove(remind);
                db.SaveChanges();

                return RedirectToAction("Index", "Remind");
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        public ActionResult CDelete(int id)
        {
            var remind = db.Reminds.Find(id);

            if (remind != null)
            {
                var result = db.Reminds.Remove(remind);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = remind.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        public ActionResult PDelete(int id)
        {
            var remind = db.Reminds.Find(id);

            if (remind != null)
            {
                var result = db.Reminds.Remove(remind);
                db.SaveChanges();

                return RedirectToAction("Detail", "Project", new { id = remind.ProjectId });
            }
            else
            {
                return View("Error", new string[] { "Not Bulunamadı" });
            }
        }
    }
}