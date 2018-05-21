using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // WhichTransaction= Hangi İşlem
        public string Who { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string WhichTransaction { get; set; }

    }
}
