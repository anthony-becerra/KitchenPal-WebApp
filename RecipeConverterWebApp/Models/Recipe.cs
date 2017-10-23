using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeConverterWebApp.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CustomRecipe { get; set; } // Did user create their own recipe?
        public string ApiRef { get; set; } // If CustomRecipe == False, store api reference here
        //public int ApplicationUserID { get; set; }
        
        // Recipe has many Ingredients
        public IList<Ingredient> Ingredients { get; set; }
    }
}
