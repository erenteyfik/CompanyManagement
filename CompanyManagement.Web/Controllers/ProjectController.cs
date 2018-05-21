using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Helper;
using CompanyManagement.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class ProjectController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Project
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;

            var project = db.Projects.OrderByDescending(o => o.End).ToPagedList<Project>(_pageNo, 11);

            return View(project);
        }

        public ActionResult Create()
        {
            ProjectCreateModel model = new ProjectCreateModel()
            {
                Start=DateTime.Now,
                End=DateTime.Now,
                customers = db.Customers.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProjectCreateModel model)
        {
            int customerid = Convert.ToInt32(model.CustomerUserName);
            var customer = db.Customers.Find(customerid);

            var x = (model.End - model.Start).TotalDays;
            int y = int.Parse(x.ToString());
            if (model.End != null || model.Start != null)
            {


            }
            var project = new Project()
            {
                CustomerUserName = customer.UserName,
                Description = model.Description,
                End = model.End,
                Title = model.Title,
                Start = model.Start,
                StateName = model.ProjectState.GetProjectStateName(),
                Sorumluenumolacak = model.Sorumluenumolacak,
                CustomerId = customer.Id,
                TimeControl = y,

            };
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CPCreate(int id)
        {

            Customer customer = db.Customers.Find(id);
            Project project = new Project()
            {
                CustomerUserName = customer.UserName,
                CustomerId = customer.Id,
                End = DateTime.Now,
                Start = DateTime.Now,
            };

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CPCreate(Project model)
        {
            Customer customer = db.Customers.Find(model.Id);

            var x = (model.End - model.Start).TotalDays;
            int y = int.Parse(x.ToString());
            if (model.End != null || model.Start != null)
            {


            }
            Project project = new Project()
            {
                Start = model.Start,
                End = model.End,
                CustomerUserName = customer.UserName,
                CustomerId = customer.Id,
                Sorumluenumolacak = model.Sorumluenumolacak,
                Title = model.Title,
                Description = model.Description,
                TimeControl = y,
                StateName = model.ProjectState.GetProjectStateName()
            };
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Detail", "Customer", new { id = model.Id });
        }

        public ActionResult Detail(int id)
        {
            Project P = db.Projects.Find(id);
            ProjectDetailModel PDM = new ProjectDetailModel()
            {
                project = new Project()
                {
                    Id = P.Id,
                    CustomerId = P.CustomerId,
                    CustomerUserName = P.CustomerUserName,
                    Description = P.Description,
                    Title = P.Title,
                    StateName = P.StateName,
                    Sorumluenumolacak = P.Sorumluenumolacak,
                    End = P.End,
                    Start = P.Start,
                    TimeControl = P.TimeControl,
                },
                reminds = db.Reminds.Where(w => w.ProjectId == P.Id).ToList(),
            };

            return View(PDM);
        }

        public ActionResult AddCost(int id)
        {

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Start,End,Description,CustomerUserName,Sorumluenumolacak,CustomerId,Company_Id,TimeControl,ProjectState,StateName")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public ActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);

            if (project != null)
            {
                var result = db.Projects.Remove(project);
                db.SaveChanges();

                return RedirectToAction("Index", "Project", new { id = project.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Proje Bulunamadı" });
            }
        }

        public ActionResult CDelete(int id)
        {
            var project = db.Projects.Find(id);

            if (project != null)
            {
                var result = db.Projects.Remove(project);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = project.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Proje Bulunamadı" });
            }
        }
    }
}