using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class OutGoingCreateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerUserName { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ProcessTime { get; set; }

        public int? Ayar { get; set; }

        public double AraToplam { get; set; }
        public string KDV { get; set; }
        public double KDVToplam { get; set; }
        public double GenelToplam { get; set; }

        public ServiceProduct ServiceProduct { get; set; }
        public List<ServiceProduct> ServiceProducts { get; set; }
        public List<Customer> Customers { get; set; }

    }
}