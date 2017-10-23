using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeConverterWebApp.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Measurement { get; set; }
        public string Name { get; set; }
        
        // An Ingredient has one Recipe
        public Recipe Recipe { get; set; }
    }
}
