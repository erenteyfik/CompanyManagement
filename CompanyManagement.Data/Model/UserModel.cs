using CompanyManagement.Data.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompanyManagement.Data.Model
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class Register
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }

    }


    public class EmployeeRegister
    {
        [Required]
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }

    }



    //public class RoleEditModel
    //{
    //    public IdentityRole role { get; set; }
    //    //public IEnumerable<User> Members { get; set; }
    //    //public IEnumerable<User> NonMembers { get; set; }

    //    //Members = admin listesi
    //    //NonMembers = user listesi
    //}

    //public class RoleUpdateModel
    //{
    //    public string RoleName { get; set; }
    //    public string RoleId { get; set; }
    //    public string[] IdsToAdd { get; set; }
    //    public string[] IdsToDelete { get; set; }
    //}
}
