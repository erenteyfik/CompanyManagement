using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class ProjectCreateModel
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TimeControl { get; set; }
        public string Description { get; set; }
        public string CustomerUserName { get; set; }
        public string Sorumluenumolacak { get; set; }

        public EnumProjectState ProjectState { get; set; }
        public string StateName { get; set; }

        public int CustomerId { get; set; }

        public List<Customer> customers { get; set; }


    }
}