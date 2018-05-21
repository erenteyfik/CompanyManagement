using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class ProjectCostOther
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitQuantities { get; set; } //Birim miktar
        public int Cost { get; set; } //Maliyet
        public int Tax { get; set; }
        public int Total { get; set; } // Total = Birim x Maliyet => sadece totali tutsakta olur ama hepsi lazım.

        public int ProjectId { get; set; }
    }
}
