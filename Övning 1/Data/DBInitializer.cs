using Microsoft.AspNetCore.Identity;
using Övning_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Övning1.Data
{
    public class DBInitializer
    {
        public void Initialize(UserManager<ApplicationUser> usermanager)
        {

            var aUser = new ApplicationUser();
            aUser.UserName = "student@tset.com";
            aUser.Email = "student@tset.com";
            var r = usermanager.CreateAsync(aUser, "Password").Result;
        }
    }
}
