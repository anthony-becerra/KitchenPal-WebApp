using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeConverterWebApp.Models
{
    public class CustomRecipeConversion
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Origin_ss { get; set; }
        public double Desired_ss { get; set; }
        public Dictionary<string, Dictionary<string, string>> Ingredients { get; set; }
    }
}
