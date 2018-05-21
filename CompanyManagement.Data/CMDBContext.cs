using CompanyManagement.Data.Entities;
using CompanyManagement.Data.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data
{
    public class CMDBContext : IdentityDbContext<CMUser>
    {
        public CMDBContext() : base("CMConnectionString")
        {

        }

        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCostOther> ProjectCostOthers { get; set; }
        public DbSet<ProjectCostEmployee> ProjectCostEmployees { get; set; }


        public DbSet<Remind> Reminds { get; set; }
        public DbSet<ServiceProduct> ServiceProducts { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InterViews> InterViews { get; set; }
        public DbSet<InterViewsList> InterViewsList { get; set; }
        public DbSet<CashAccount> CashAccounts { get; set; }

    }
}
