    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    //Muhasebe
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        //Kasa ve Banka
        public ActionResult Bank()
        {
            return View();
        }

        public ActionResult BankCreate()
        {
            return View();
        }


        public ActionResult BankDetail()
        {
            return View();
        }

        //Collect = Almak , Biriktirmek => Tahsilat
        public ActionResult Collect()
        {
            return View();
        }

        public ActionResult CollectCreate()
        {
            return View();
        }

        public ActionResult CollectDetail()
        {
            return View();
        }


        //Ödemeler
        public ActionResult Payments()
        {
            return View();
        }

        public ActionResult PaymentsCreate()
        {
            return View();
        }

        public ActionResult PaymentsDetail()
        {
            return View();
        }

        //Satış Faturaları
        public ActionResult SaleInvoice()
        {
            return View();
        }

        public ActionResult SaleInvoiceCreate()
        {
            return View();
        }

        public ActionResult SaleInvoiceDetail()
        {
            return View();
        }

        //Alış Faturaları
        public ActionResult BuyInvoice()
        {
            return View();
        }

        public ActionResult BuyInvoiceCreate()
        {
            return View();
        }

        public ActionResult BuyInvoiceDetail()
        {
            return View();
        }

        //Harcamalar
        public ActionResult Expenses()
        {
            return View();
        }

        public ActionResult ExpensesCreate()
        {
            return View();
        }

        public ActionResult ExpensesDetail()
        {
            return View();
        }


        //Ürün & Hizmetler
        public ActionResult Product_Services()
        {
            return View();
        }

        public ActionResult Product_ServicesCreate()
        {
            return View();
        }

        public ActionResult Product_ServicesDetail()
        {
            return View();
        }
    }
}