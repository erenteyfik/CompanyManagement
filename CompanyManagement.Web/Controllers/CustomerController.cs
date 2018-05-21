using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class CustomerController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Customer
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;
            var customer = db.Customers.Where(w => w.CustomerActive == true).OrderByDescending(o => o.CreateTime).ToPagedList<Customer>(_pageNo, 11);

            return View(customer);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreatePost(Customer model)
        {
            var customer = new Customer()
            {
                Id = model.Id,
                UserName = model.UserName,
                AuthorizedPerson = model.AuthorizedPerson,
                Email = model.Email,
                Phone = model.Phone,
                MobilePhone = model.MobilePhone,
                Budget = model.Budget, //budget= bütçe
                CustomerActive = true,

                BankName = model.BankName,
                IBANno = model.IBANno,

                CompanyTitle = model.CompanyTitle,
                TaxOffice = model.TaxOffice,
                TaxorTCNo = model.TaxorTCNo,
                CompanyPhone = model.CompanyPhone,
                FaxNo = model.FaxNo,
                Address = model.Address,
                Province = model.Province,
                District = model.District,
                WebAddress = model.WebAddress,
                CreateTime = DateTime.Now,

                CompanyId = 1, //Satış işlemi bittikten sonraki kısım
            };

            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,AuthorizedPerson,Email,Phone,MobilePhone,Budget,CustomerActive,BankName,IBANno,CompanyTitle,TaxOffice,TaxorTCNo,CompanyPhone,FaxNo,Address,Province,District,WebAddress,CreateTime,CompanyId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Detail(int id)
        {
            TempData.Remove("Outgoing");
            Customer C = db.Customers.Find(id);
            CustomerDetailModel CDM = new CustomerDetailModel()
            {
                customer = new Customer()
                {
                    Id = C.Id,
                    UserName = C.UserName,
                    AuthorizedPerson = C.AuthorizedPerson,
                    Email = C.Email,
                    Phone = C.Phone,
                    MobilePhone = C.MobilePhone,
                    Budget = C.Budget,
                    CustomerActive = true,

                    BankName = C.BankName,
                    IBANno = C.IBANno,

                    CompanyTitle = C.CompanyTitle,
                    TaxOffice = C.TaxOffice,
                    TaxorTCNo = C.TaxorTCNo,
                    CompanyPhone = C.CompanyPhone,
                    FaxNo = C.FaxNo,
                    Address = C.Address,
                    Province = C.Province,
                    District = C.District,
                    WebAddress = C.WebAddress,
                    CreateTime = DateTime.Now,

                    CompanyId = 1,

                },

                InterViews = db.InterViews.Where(w => w.CustomerId == C.Id).ToList(), // görüşmeler
                Incomings = db.Invoices.OfType<Incoming>().Where(w => w.CustomerId == C.Id).ToList(),
                OutGoings = db.Invoices.OfType<OutGoing>().Where(w => w.CustomerId == C.Id).ToList(),
                PIncomings = db.Payments.OfType<PIncoming>().Where(w => w.CustomerId == C.Id).ToList(),
                POutGoings = db.Payments.OfType<POutGoing>().Where(w => w.CustomerId == C.Id).ToList(),
                projects = db.Projects.Where(w => w.CustomerId == C.Id).ToList(),
                reminds = db.Reminds.Where(w => w.CustomerId == C.Id).ToList(),
                CashAccounts = db.CashAccounts.ToList(),
                //PaymentIncome = db.Payments.OfType<PIncoming>().Where(w=>w.CustomerId == C.Id).Sum(s=>s.Total),
                //PaymentOutgoing = db.Payments.OfType<POutGoing>().Where(w => w.CustomerId == C.Id).Sum(s=>s.Total),
                //InvoiceOutgoing = db.Invoices.OfType<OutGoing>().Where(w=>w.CustomerId == C.Id).Sum(s=>s.Total),//satış faturasıları toplamı için
                //InvoiceIncome = db.Invoices.OfType<Incoming>().Where(w=>w.CustomerId == C.Id).Sum(s=>s.Total),
                //Sum() ?? 0 
            };
            return View(CDM);
        }

        [HttpPost]
        public ActionResult DetailPaymentPost(CustomerDetailModel model)
        {
            var customerName = db.Customers.Find(model.customer.Id).UserName;
            if (model.PIncoming != null)
            {
                var incoming = new PIncoming()
                {
                    CreateTime = model.PIncoming.CreateTime,
                    Total = model.PIncoming.Total,
                    WhichSafe = db.CashAccounts.Find(model.CashAccountId).AccountName,
                    Description = model.PIncoming.WhichSafe,
                    CustomerId = model.customer.Id,
                    CustomerUserName = customerName,
                    WhoUser = "...",
                    CashAccountId = model.CashAccountId,

                };
                db.Payments.Add(incoming);
                db.SaveChanges();
            }
            if (model.POutGoing != null)
            {
                var outGoing = new POutGoing()
                {
                    CreateTime = model.POutGoing.CreateTime,
                    Total = model.POutGoing.Total,
                    WhichSafe = db.CashAccounts.Find(model.CashAccountId).AccountName,
                    Description = model.POutGoing.Description,
                    CustomerId = model.customer.Id,
                    CustomerUserName = customerName,
                    WhoUser = "...",
                    CashAccountId = model.CashAccountId,
                };
                db.Payments.Add(outGoing);
                db.SaveChanges();
            }

            return RedirectToAction("Detail", new { id = model.customer.Id });
        }

        public ActionResult Delete(int id)
        {
            //Customer customer = db.Customers.Find(id);
            //customer.CustomerActive = false;
            //db.Entry(customer).State = EntityState.Modified;
            //db.SaveChanges();

            var customer = db.Customers.Find(id);

            if (customer != null)
            {
                var result = db.Customers.Remove(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Error", new string[] { "Müşteri Bulunamadı" });
            }

        }
    }
}