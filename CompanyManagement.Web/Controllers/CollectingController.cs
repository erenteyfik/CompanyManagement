using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{

    //POutgoing Tahsilat
    public class CollectingController : Controller
    {
        private CMDBContext db = new CMDBContext();

        // GET: Collecting
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;
            var pIncomings = db.Payments.OfType<PIncoming>().OrderByDescending(o => o.CreateTime).ToPagedList<PIncoming>(_pageNo, 11);

            CollectingIndexModel model = new CollectingIndexModel()
            {
                PIncomings = pIncomings,
                customers = db.Customers.Where(w => w.CustomerActive == true).ToList(),
                CashAccounts = db.CashAccounts.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CollectingIndexModel model)
        {
            var customerName = db.Customers.Find(model.PIncoming.CustomerId).UserName;
            if (model != null)
            {
                var PIncoming = new PIncoming()
                {
                    CreateTime = model.PIncoming.CreateTime,
                    Total = model.PIncoming.Total,
                    WhichSafe = db.CashAccounts.Find(model.CashAccountId).AccountName,
                    Description = model.PIncoming.Description,
                    CustomerId = model.PIncoming.CustomerId,
                    CustomerUserName = customerName,
                    WhoUser = "...",
                    CashAccountId = model.CashAccountId,
                    
                };
                db.Payments.Add(PIncoming);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Collecting");
        }


        public ActionResult Detail(int id)
        {
            
            PIncoming incoming = db.Payments.OfType<PIncoming>().FirstOrDefault(f => f.Id == id);
            //incoming.Customer = db.Customers.Find(incoming.CustomerId);
            return View(incoming);
        }

        public ActionResult Edit()
        {
            return View();
        }


        public ActionResult CDelete(int id)
        {
            var payment = db.Payments.Find(id);

            if (payment != null)
            {
                var result = db.Payments.Remove(payment);
                db.SaveChanges();

                return RedirectToAction("Detail", "Customer", new { id = payment.CustomerId });
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }

        public ActionResult Delete(int id)
        {
            var payment = db.Payments.Find(id);

            if (payment != null)
            {
                var result = db.Payments.Remove(payment);
                db.SaveChanges();

                return RedirectToAction("Index", "Collecting");
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }
    }
}