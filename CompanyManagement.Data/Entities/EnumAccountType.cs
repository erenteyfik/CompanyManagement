using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public enum EnumAccountType
    {
        [Display(Name = "Kasa Hesabı")]
        CashAccount,

        [Display(Name = "Banka Hesabı")]
        BankAccount,
    }
}
