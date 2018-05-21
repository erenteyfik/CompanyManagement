using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public enum EnumTaxValue
    {
        [Display(Name = "%18")]
        eighteen,

        [Display(Name = "%8")]
        eight,

        [Display(Name = "%1")]
        one,

        [Display(Name = "%0")]
        zero,

    }
}
