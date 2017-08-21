﻿using Microsoft.AspNetCore.Identity;
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
                var cheese = new Ingredient { Name = "Cheese" };
                var tomatoe = new Ingredient { Name = "Tomatoe" };
                var ham = new Ingredient { Name = "Ham" };
                var mushroom = new Ingredient { Name = "Mushrooms" };
                var pineapple = new Ingredient { Name = "Pineapple" };

                context.Ingredients.Add(cheese);
                context.Ingredients.Add(tomatoe);
                context.Ingredients.Add(ham);
                context.Ingredients.Add(mushroom);
                context.Ingredients.Add(pineapple);

                var cappricciosa = new Dish { Name = "Cappricciosa" , Price = 79};
                var margherita = new Dish { Name = "Margherita", Price = 69 };
                var hawaii = new Dish { Name = "Hawaii", Price = 85 };

                var cappricciosaCheese = new DishIngredient { Dish = cappricciosa, Ingredient = cheese };
                var cappricciosaHam = new DishIngredient { Dish = cappricciosa, Ingredient = ham };
                var cappricciosaTomatoe = new DishIngredient { Dish = cappricciosa, Ingredient = tomatoe };
                var cappriocciosaMushrooms = new DishIngredient { Dish = cappricciosa, Ingredient = mushroom };

                cappricciosa.DishIngredients = new List<DishIngredient>();
                cappricciosa.DishIngredients.Add(cappricciosaCheese);
                cappricciosa.DishIngredients.Add(cappricciosaTomatoe);
                cappricciosa.DishIngredients.Add(cappricciosaHam);
                cappricciosa.DishIngredients.Add(cappriocciosaMushrooms);

                var margheritaCheese = new DishIngredient { Dish = margherita, Ingredient = cheese };
                var margheritaHam = new DishIngredient { Dish = margherita, Ingredient = ham };
                var margheritaTomatoe = new DishIngredient { Dish = margherita, Ingredient = tomatoe };

                margherita.DishIngredients = new List<DishIngredient>();
                margherita.DishIngredients.Add(margheritaCheese);
                margherita.DishIngredients.Add(margheritaHam);
                margherita.DishIngredients.Add(margheritaTomatoe);

                //context.AddRange(cappricciosaCheese, cappricciosaHam, cappricciosaTomatoe, cappriocciosaMushrooms);
                //context.AddRange(cappricciosa, margherita, hawaii);
                context.Dishes.Add(cappricciosa);
                context.Dishes.Add(margherita);
                context.Dishes.Add(hawaii);
                context.SaveChanges();
            }
        }
    }
}
