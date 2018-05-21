using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public abstract class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string CustomerUserName { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    //Son Satış Faturaları için 
    [Table("Incoming")]
    public class Incoming : Invoice
    {
        public double AraToplam { get; set; }
        public double KDVToplam { get; set; }
        public double GenelToplam { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ProcessTime { get; set; }

        public ServiceProduct SProduct { get; set; }
        public virtual ICollection<ServiceProduct> Products { get; set; }
 
    }

    //Son Alış Faturaları için 
    [Table("OutGoing")]
    public class OutGoing : Invoice
    {
        public double AraToplam { get; set; }
        public double KDVToplam { get; set; }
        public double GenelToplam { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? ProcessTime { get; set; }

        public ServiceProduct SProduct { get; set; }
        public virtual ICollection<ServiceProduct> Products { get; set; }


    }
}
