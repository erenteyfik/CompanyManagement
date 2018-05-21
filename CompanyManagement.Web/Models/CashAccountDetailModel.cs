using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class CashAccountDetailModel
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int OpeningAmount { get; set; }

        public string BankName { get; set; }
        public int BankAccountNo { get; set; }
        public string IBAN { get; set; }
        public string BranchCode { get; set; }

        public Remind remind { get; set; }
        public List<Remind> Reminds { get; set; }
        public List<Payment> Payment { get; set; }
    }
}