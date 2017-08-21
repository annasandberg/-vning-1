using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Övning_1.Data;
using Microsoft.AspNetCore.Authorization;

namespace Övning_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public DishController(Data.ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }


        public IActionResult Index()
        {
            var model = _context.Dishes.ToList();
            return View(model);
        }
    }
}