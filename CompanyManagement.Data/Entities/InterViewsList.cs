using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class InterViewsList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public string WithWho { get; set; } //Kimle görüştü
        public string WhoUser { get; set; } //Kim görüştü
        public bool Result { get; set; } // olumlu olumsuz
        public string InterViewType { get; set; }

        public int InterViewsId { get; set; }
    }
}
