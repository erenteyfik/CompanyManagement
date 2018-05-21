using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class CustomerDetailModel
    {
        //detail için
        public Customer customer { get; set; }

        //create için
        public Remind remind { get; set; }
        public Project project { get; set; }
        public PIncoming PIncoming { get; set; }
        public POutGoing POutGoing { get; set; }

        //Listelemek için
        public List<Project> projects { get; set; }
        public List<Remind> reminds { get; set; }


        public List<POutGoing> POutGoings { get; set; }
        public List<PIncoming> PIncomings { get; set; }

        public List<OutGoing> OutGoings { get; set; }
        public List<Incoming> Incomings { get; set; }

        public List<InterViews> InterViews { get; set; }

        public List<CashAccount> CashAccounts { get; set; }
        public int CashAccountId { get; set; }

        //public int PaymentIncome { get; set; }
        //public int PaymentOutgoing { get; set; }

        //public double InvoiceIncome { get; set; }
        //public double InvoiceOutgoing { get; set; }


    }
}