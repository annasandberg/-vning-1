using Microsoft.AspNetCore.Identity;
using Övning_1.Data;
using Övning_1.Models;
using Övning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Övning1.Data
{
    public class DBInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> roleManager)
        {

            var aUser = new ApplicationUser();
            aUser.UserName = "student@tset.com";
            aUser.Email = "student@tset.com";
            var r = usermanager.CreateAsync(aUser, "Pa$$w0rd").Result;

            var adminRole = new IdentityRole { Name = "Admin" };
            var roleresult = roleManager.CreateAsync(adminRole).Result;

            var adminUser = new ApplicationUser();
            adminUser.UserName = "admin@tset.com";
            adminUser.Email = "admin@tset.com";
            var adminUserResult= usermanager.CreateAsync(adminUser, "Pa$$w0rd").Result;
            if (adminUserResult.Succeeded)
            {
                usermanager.AddToRoleAsync(adminUser, adminRole.Name);
            }

   
            if (context.Dishes.ToList().Count == 0)
            {
                var cappricciosa = new Dish { Name = "Cappricciosa" , Price = 79};
                var margherita = new Dish { Name = "Margherita", Price = 69 };
                var hawaii = new Dish { Name = "Hawaii", Price = 85 };

                context.AddRange(cappricciosa, margherita, hawaii);
                context.SaveChanges();
            }
        }
    }
}
