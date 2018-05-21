using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Models
{
    public class ProjectDetailModel
    {
        //detail için
        public Project project { get; set; }

        public IEnumerable<Remind> reminds { get; set; }
        //create için
        public Remind remind { get; set; }
    }
}