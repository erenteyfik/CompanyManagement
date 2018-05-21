using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Data.Identity
{
    public class UserPasswordValidator : PasswordValidator
    {

        // olay şu AREAS/accountcontroller_passwordvalidator daki özellikleri extra bir özellik eklemek için türettik 
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            //parola için extra istediğimiz özellikleri ekliyeceğiz
            var result = await base.ValidateAsync(password);

            if (password.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Parola ardışık sayısal ifade içeremez");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
