using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeConverterWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeConverterWebApp.ViewModels
{
    public class ConvertCustomRecipeViewModel
    {
        [Required]
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your recipe a description.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Original Serving Size")]
        public int OriginalServeSize { get; set; }

        [Required]
        [Display(Name = "Desired Serving Size")]
        public int DesiredServeSize { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "MeasurementID")]
        public int MeasurementID { get; set; }

        public List<SelectListItem> Measurements { get; set; }

        [Required]
        [Display(Name = "Ingredient")]
        public string Ingredient { get; set; }


        // Default constructor
        public ConvertCustomRecipeViewModel() { }


        public ConvertCustomRecipeViewModel(IEnumerable<Measurement> measurements)
        {

            Measurements = new List<SelectListItem>();

            // Loop through list of Categories to create: <option value="CategoryID">Category Name</option>
            foreach (var measurement in measurements)
            {
                Measurements.Add(new SelectListItem
                {
                    Value = measurement.ID.ToString(),
                    Text = measurement.Name
                });
            }
        }
    }
}
