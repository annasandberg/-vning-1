﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Övning1.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [DisplayName ("Ingredients")]
        public List<DishIngredient> DishIngredients { get; set; }
    }
}
