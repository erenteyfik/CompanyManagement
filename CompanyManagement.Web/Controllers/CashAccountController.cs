using CompanyManagement.Data;
using CompanyManagement.Data.Entities;
using CompanyManagement.Web.Helper;
using CompanyManagement.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.Web.Controllers
{
    public class CashAccountController : Controller
    {
        private CMDBContext db = new CMDBContext();
        // GET: CashAccount
        public ActionResult Index(int? pageNO)
        {
            int _pageNo = pageNO ?? 1;
            var cashAccount = db.CashAccounts.OrderByDescending(o => o.OpeningAmount).ToPagedList<CashAccount>(_pageNo, 11);
            return View(cashAccount);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CashAccount model)
        {
            var cashAccount = new CashAccount()
            {
                AccountName = model.AccountName,
                CompanyId = 1,
                AccountType = model.AccountType,
                OpeningAmount = model.OpeningAmount,
                BankName = model.BankName,
                BankAccountNo = model.BankAccountNo,
                BranchCode = model.BranchCode, // Şube Kodu
                IBAN = model.IBAN
            };
            db.CashAccounts.Add(cashAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var model = db.CashAccounts.FirstOrDefault(f => f.Id == id);
            var cashAccount = new CashAccountDetailModel()
            {
                AccountName = model.AccountName,
                AccountType = model.AccountType.GetAccountTypeName(),
                CompanyId = model.CompanyId,
                Id = model.Id,
                OpeningAmount = model.OpeningAmount,
                BankName = model.BankName,
                BankAccountNo = model.BankAccountNo,
                BranchCode = model.BranchCode,
                IBAN = model.IBAN,
                Reminds = db.Reminds.Where(w => w.CashAccountId == id).ToList(),
                Payment = db.Payments.Where(w=>w.CashAccountId == id).ToList(),
            };
            return View(cashAccount);
        }

        public ActionResult Delete(int id)
        {
            var cashAccount = db.CashAccounts.Find(id);

            if (cashAccount != null)
            {
                var result = db.CashAccounts.Remove(cashAccount);
                db.SaveChanges();

                return RedirectToAction("Index", "CashAccount");
            }
            else
            {
                return View("Error", new string[] { "Hesap Bulunamadı" });
            }
        }
    }
}