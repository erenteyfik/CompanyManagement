using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Yetkili kişi bilgileri Username = Code35  AuthorizedPerson=Teyfik EREN
        public string UserName { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Budget { get; set; }
        public bool CustomerActive { get; set; }

        //Banka bilgileri
        public string BankName { get; set; }
        public string IBANno { get; set; }

        //Firma bilgileri   CompanyTitle= Firma unvanı TaxOfice= Vergi Dairesi
        public string CompanyTitle { get; set; }
        public string TaxOffice { get; set; }
        public string TaxorTCNo { get; set; }
        public string CompanyPhone { get; set; }
        public string FaxNo { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string WebAddress { get; set; }

        //
        public DateTime CreateTime { get; set; }

        //public enum CompanyType
        //{
        //    Friend,
        //    Internet,
        //}
        public virtual ICollection<Remind> Reminds { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }

        public int CompanyId { get; set; }

    }
}
