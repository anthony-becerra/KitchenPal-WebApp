using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeConverterWebApp.Data;
using RecipeConverterWebApp.Models;
using RecipeConverterWebApp.ViewModels;

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
            return View();
        }

        public IActionResult CustomRecipe()
        {
            // Get list of all Measurement objects and pass into ViewModel.
            List<Measurement> measurements = context.Measurements.ToList();
            ConvertCustomRecipeViewModel ModelCustomRecipe = new ConvertCustomRecipeViewModel(measurements);
            return View(ModelCustomRecipe);
        }

        [HttpPost]
        public IActionResult CustomRecipe(ConvertCustomRecipeViewModel convertCustomRecipeViewModel)
        {
            if(ModelState.IsValid)
            {
                return Redirect("/ConvertRecipe");
            }

            List<Measurement> measurements = context.Measurements.ToList();
            ConvertCustomRecipeViewModel ModelError = new ConvertCustomRecipeViewModel(measurements);
            return View(ModelError);
        }

        /* // Used to add measurements to database.
        public IActionResult AddMeasurements()
        {
            List<string> measurements = new List<string>(new string[] 
            {
                "teaspoon (tsp.)",
                "tablespoon (tbsp.)",
                "ounce (oz)",
                "fluid ounce (fl oz)",
                "pound (lb)",
                "cup (c)",
                "pint (pt)",
                "quart (qt)",
                "gallon (gal)",
                "milliliter (ml)",
                "liter (l)",
                "each"
            });

            foreach (string unit in measurements)
            {
                Measurement newMeasurement = new Measurement
                {
                    Name = unit // assign value of Name from the ViewModel
                };
                context.Measurements.Add(newMeasurement); // Add newCategory to the database context
                context.SaveChanges(); // Save changes to the database
            }

            return View();
        }
        */
    }
}
