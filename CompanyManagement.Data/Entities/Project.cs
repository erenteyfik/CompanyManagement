using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TimeControl { get; set; }
        public string Description { get; set; }
        public string CustomerUserName { get; set; }
        public string Sorumluenumolacak { get; set; }

        public EnumProjectState ProjectState { get; set; }
        public string StateName { get; set; }

        //public enum ProductState
        //{
        //    Onaylandı,
        //    Beklemede,
        //}

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<ProjectCostOther> ProjectCostOthers { get; set; }
        public virtual ICollection<ProjectCostEmployee> ProjectCostEmployees { get; set; }


    }
}
