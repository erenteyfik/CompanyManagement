using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class Product_ServicesController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Product_Services
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CCreate(/*int id*/)
        {
            //Customer customer = db.Customers.Find(id);
            //ServiceProduct product = new ServiceProduct()
            //{
                
            //};

            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        [HttpPost]
        public ActionResult CCreate(ServiceProduct model)
        {

            return RedirectToAction("CICreate", "Invoice", new { id = model.Id });
        }
      
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}