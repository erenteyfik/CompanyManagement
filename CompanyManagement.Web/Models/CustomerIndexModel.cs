using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class CustomerIndexModel
    {
        public Customer customer { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}