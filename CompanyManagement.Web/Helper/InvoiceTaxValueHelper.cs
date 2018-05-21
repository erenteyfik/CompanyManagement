using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Helper
{
    public static class InvoiceTaxValueHelper
    {
        public static int GetTaxValue(this EnumTaxValue taxvalue)
        {
            int result = 1;

            switch (taxvalue)
            {
                case EnumTaxValue.eighteen:
                    result = 18;
                    break;
                case EnumTaxValue.eight:
                    result = 8;
                    break;
                case EnumTaxValue.one:
                    result = 1;
                    break;
                case EnumTaxValue.zero:
                    result = 0;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}