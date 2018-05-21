using CompanyManagement.Data.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class PaymentIndexModel
    {
        public POutGoing POutGoing { get; set; }
        public List<Customer> customers { get; set; }
        public IPagedList<POutGoing> POutGoings { get; set; }

        public List<CashAccount> CashAccounts { get; set; }
        public int CashAccountId { get; set; }
    }
}