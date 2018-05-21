using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    //Hatırlatma
    public class Remind
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UploadTime { get; set; }
        public string Description { get; set; }
        public string WhoUser { get; set; }

        public int? ProjectId { get; set; }
        public int? CompanyId { get; set; }
        public int? CashAccountId { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
