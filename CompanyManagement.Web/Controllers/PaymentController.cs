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

    //PIncoming Ödemeler
    public class PaymentController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Payment
        public ActionResult Index(int? pageNO)
        {

            int _pageNo = pageNO ?? 1;
            var pOutGoing = db.Payments.OfType<POutGoing>().OrderByDescending(o => o.CreateTime).ToPagedList<POutGoing>(_pageNo, 11);

            PaymentIndexModel model = new PaymentIndexModel()
            {
                POutGoings = pOutGoing,
                customers = db.Customers.Where(w => w.CustomerActive == true).ToList(),
                CashAccounts = db.CashAccounts.ToList(),
            };
       
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PaymentIndexModel model)
        {

            var customerName = db.Customers.Find(model.POutGoing.CustomerId).UserName;
            if (model != null)
            {
                var pOutGoing = new POutGoing()
                {
                    CreateTime = model.POutGoing.CreateTime,
                    Total = model.POutGoing.Total,
                    WhichSafe = db.CashAccounts.Find(model.CashAccountId).AccountName,
                    Description = model.POutGoing.Description,
                    CustomerId = model.POutGoing.CustomerId,
                    CustomerUserName = customerName,
                    WhoUser = "...",
                    CashAccountId = model.CashAccountId,
                };
                db.Payments.Add(pOutGoing);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Payment");
        }

        public ActionResult Detail(int id)
        {

            POutGoing outGoing = db.Payments.OfType<POutGoing>().FirstOrDefault(f => f.Id == id);
            //incoming.Customer = db.Customers.Find(incoming.CustomerId);
            return View(outGoing);
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

                return RedirectToAction("Index", "Payment");
            }
            else
            {
                return View("Error", new string[] { "Fatura Bulunamadı" });
            }
        }
    }
}