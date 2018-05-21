using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Identity
{
    public class Role : IdentityRole
    {
        //extra özellikler eklemek icin ApplicationRole oluşturduk.
        public string Description { get; set; }
    }
}
