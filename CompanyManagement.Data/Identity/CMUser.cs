using CompanyManagement.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Identity
{
    public class CMUser : IdentityUser
    {
        //extra özellikler eklemek icin CMUser oluşturduk.


        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
