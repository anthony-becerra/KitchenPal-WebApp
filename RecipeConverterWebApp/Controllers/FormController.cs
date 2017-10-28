using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeConverterWebApp.Controllers
{
    public class FormController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public object AddForm(TESTCALL recipe)
        {
            double Convert_ratio = recipe.Desired_ss / recipe.Origin_ss;

            foreach(KeyValuePair<string, Dictionary<string,string>> ingredient in recipe.Ingredients)
            {
                /*foreach(KeyValuePair<string, string> ing_content in */
                if(ingredient.Value.ContainsKey("quantity"))
                {
                    double quantity = double.Parse(ingredient.Value["quantity"]);
                    quantity *= Convert_ratio;
                    ingredient.Value["quantity"] = quantity.ToString();
                    //if (ing_content.Key.Equals("quantity"))
                    //{
                    //    int quantity = int.Parse(ing_content.Value);
                    //    quantity *= Convert_ratio;
                    //    KeyValuePair<string, string> newKVP = new KeyValuePair<string, string>("quantity", quantity.ToString());
                    //    ing_content = newKVP;
                    //}
                }
            }
            
            return recipe; // Going to site.js as "result" on success
        }

    }

    public class TESTCALL
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Origin_ss { get; set; }
        public double Desired_ss { get; set; }
        public Dictionary<string, Dictionary<string, string>> Ingredients { get; set; }
    }
}
