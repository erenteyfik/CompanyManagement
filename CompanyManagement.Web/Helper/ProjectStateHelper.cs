using CompanyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.Web.Helper
{
    public static class ProjectStateHelper
    {
        public static string GetProjectStateName(this EnumProjectState projectState)
        {
            string result = "";

            switch (projectState)
            {
                case EnumProjectState.WillBePlanned:
                    result = "PLANLANAN";
                    break;
                case EnumProjectState.Continues:
                    result = "DEVAM EDEN";
                    break;
                case EnumProjectState.END:
                    result = "SONLANAN";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}