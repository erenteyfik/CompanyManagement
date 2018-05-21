using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: Expenses
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;

            var expenses = db.Expensess.OrderByDescending(w => w.End).ToPagedList<Expenses>(_pageNo, 11);

            return View(expenses);
        }

        public ActionResult Create()
        {
            return View();
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