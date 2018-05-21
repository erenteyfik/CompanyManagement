using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public class ProjectCostEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }
        public string EmployeeName { get; set; }
        public int? MonthlySalary { get; set; } //Aylık Maaşı
        public int? MonthlyTax { get; set; } //Aylık Vergisi
        public int? MonthlyInsurance { get; set; } //Aylık Sigorta
        public int? MonthlyMeal { get; set; } //Aylık Yemek
        public int? MonthlyCarService { get; set; } //Aylık Araba Servisi
        public int? MonthlyOtherExpenses { get; set; } //Aylık Diger giderler
        public int Total { get; set; } // 1 işcinin aylık maliyeti

        public int ProjectId { get; set; }
    }
}
