using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoockingBook
{
    public class Recipe
    {
        private int _recipeId;
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeDescription { get; set; }
        public string CuisineType { get; set; }
        public string RecipeIngredients { get; set; }
    }
}
