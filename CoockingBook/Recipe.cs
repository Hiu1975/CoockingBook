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
        public int RecipeId { get { return _recipeId; } set { _recipeId = value + 1000; } }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public string CuisineType { get; set; }
        public string RecipeIngredients { get; set; }
    }
}
