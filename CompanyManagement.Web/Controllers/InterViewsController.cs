using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class InterViewsController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: InterViews
        public ActionResult Index()
        {
            return View();
        }

        //Görüşme yaratmak için
        public ActionResult Create(int id)
        {
            InterViews interviews = new InterViews()
            {
                CustomerId = id,
            };

            return View(interviews);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(InterViews model)
        {
            InterViews interviews = new InterViews()
            {
                CustomerId = model.CustomerId,
                Description = model.Description,
                CreateTime = DateTime.Now,
                InterViewType = model.InterViewType,
                Result = model.Result,
                WhoUser = model.WhoUser,
                WithWho = model.WithWho,
                Title = model.Title,
            };
            db.InterViews.Add(interviews);
            db.SaveChanges();
            return RedirectToAction("Detail", "Customer", new { id = model.CustomerId });
        }

        //Olan bir görüşmenin altına onla ilgili devam eden görüşmeleri yaratmak için
        public ActionResult InterViewsListCreate(int id)
        {
            InterViews interview = db.InterViews.Find(id);
            InterViewsList IV = new InterViewsList()
            {
                InterViewsId = id,
                //WithWho = interview.WithWho,

            };
            return View(IV);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InterViewsListCreate(InterViewsList model)
        {
            InterViewsList IV = new InterViewsList()
            {
                WhoUser = model.WhoUser,
                WithWho = model.WithWho,
                Description = model.Description,
                CreateTime = DateTime.Now,
                InterViewsId = model.InterViewsId,
                InterViewType = model.InterViewType,
                Result = model.Result,

            };
            db.InterViewsList.Add(IV);
            db.SaveChanges();
            return RedirectToAction("Detail", "InterViews", new { id = model.InterViewsId });
        }

        //Bir görüşme ile ilgili detayları listelemek için
        public ActionResult Detail(int id)
        {
            InterViews interview = db.InterViews.Find(id);
            interview.interviewLIST = db.InterViewsList.Where(w => w.InterViewsId == id).ToList();
            return View(interview);
        }

        public ActionResult Delete(int id)
        {
            var interViewList = db.InterViewsList.Find(id);

            if (interViewList != null)
            {
                var result = db.InterViewsList.Remove(interViewList);
                db.SaveChanges();

                return RedirectToAction("Detail", "InterViews", new { id = interViewList.InterViewsId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        public ActionResult CDelete(int id)
        {
            var interViews = db.InterViews.Find(id);

            if (interViews != null)
            {
                var result = db.InterViews.Remove(interViews);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = interViews.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }
    }
}