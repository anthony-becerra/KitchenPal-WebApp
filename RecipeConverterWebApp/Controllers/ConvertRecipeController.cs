using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeConverterWebApp.Data;
using RecipeConverterWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeConverterWebApp.Controllers
{
    public class ConvertRecipeController : Controller
    {
        // Used to interface with database
        private ApplicationDbContext context;

        // Gives controller class dbContext. 
        // Sets private "context" field to dbContext passed in.
        public ConvertRecipeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            // Get list of recipes for user
            List<Recipe> Recipes = context.Recipes.ToList();

            return View();
        }
    }
}
