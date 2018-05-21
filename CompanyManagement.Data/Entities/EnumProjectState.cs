using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Entities
{
    public enum EnumProjectState
    {
        [Display(Name = "PLANLANAN")]
        WillBePlanned,

        [Display(Name = "DEVAM EDEN")]
        Continues,

        [Display(Name = "SONLANAN")]
        END,

    }
}
