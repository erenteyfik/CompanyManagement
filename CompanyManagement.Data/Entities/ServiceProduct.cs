using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    // HİZMET/ÜRÜN Fatura için birden fazla hizmet varsa eklemek icin  
    public class ServiceProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Urun Quantity=Adet
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public EnumTaxValue Tax { get; set; }
        public double Total { get; set; }
        public string UniqueId { get; set; }

        public int? InvoiceId { get; set; }
    }
}
