using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class InterViews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public string WithWho { get; set; } //Kimle görüştü
        public string WhoUser { get; set; } //Kim görüştü
        public bool Result { get; set; } // olumlu olumsuz
        public string InterViewType { get; set; }
        public virtual ICollection<InterViewsList> interviewLIST { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
