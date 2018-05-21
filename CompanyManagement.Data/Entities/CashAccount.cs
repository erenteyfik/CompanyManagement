using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    //Kasa Hesabı
    public class CashAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? CompanyId { get; set; }
        public string AccountName { get; set; }
        public EnumAccountType AccountType { get; set; }
        public string AccountRate { get; set; } //Hesap kuru
        public int OpeningAmount { get; set; }

        public string BankName { get; set; }
        public int BankAccountNo { get; set; }
        public string IBAN { get; set; }
        public string BranchCode { get; set; }

    }
}
