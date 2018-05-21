using CompanyManagement.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<CMUser> CMUsers { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Remind> Reminds { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }

        public virtual ICollection<CashAccount> CashAccounts { get; set; }

    }
}
