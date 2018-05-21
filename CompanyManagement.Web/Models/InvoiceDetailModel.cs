using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class InvoiceDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerEmail { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? ProcessTime { get; set; }
        public double AraToplam { get; set; }
        public double KDVToplam { get; set; }
        public double GenelToplam { get; set; }

        public List<ServiceProduct> ServiceProducts { get; set; }
    }
}