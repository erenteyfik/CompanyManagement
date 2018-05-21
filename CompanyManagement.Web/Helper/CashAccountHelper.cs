using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Helper
{
    public static class CashAccountHelper
    {
        public static string GetAccountTypeName(this EnumAccountType accountType)
        {
            string result = "";

            switch (accountType)
            {
                case EnumAccountType.CashAccount:
                    result = "Kasa Hesabı";
                    break;
                case EnumAccountType.BankAccount:
                    result = "Banka Hesabı";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}