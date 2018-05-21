using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class CustomerInvoceSellModel
    {
        public Incoming Incoming { get; set; }
        public virtual ICollection<ServiceProduct> Products { get; set; }

    }
}