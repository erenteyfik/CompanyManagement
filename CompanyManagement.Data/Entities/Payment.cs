using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public abstract class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
        public string WhoUser { get; set; }
        public string CustomerUserName { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CashAccountId { get; set; }
    }

    [Table("PaymentIncoming")]
    public class PIncoming : Payment
    {
        public DateTime CreateTime { get; set; }
        public int Total { get; set; }
        public string WhichSafe { get; set; }
    }

    [Table("PaymentOutGoing")]
    public class POutGoing : Payment
    {
        public DateTime CreateTime { get; set; }
        public int Total { get; set; }
        public string WhichSafe { get; set; }
    }
}
