using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoockingBook
{
    public class RecipeService
    {
        public List<Recipe> Recipes { get; set; }
        public RecipeService()
        {
            Recipes = new List<Recipe>();
        }

        int id = 0;
        public void CreateStartingList()
        {
            Recipes.Add(new Recipe() { RecipeId = id++, CuisineType = "1", RecipeName = "Butter chicken", RecipeDescription = "Chicken curry masala", RecipeIngredients = "chicken, onion, potato, cream, garlic, ginger, indian spices" });
            Recipes.Add(new Recipe() { RecipeId = id++, CuisineType = "1", RecipeName = "Naan garlic", RecipeDescription = "Prawn curry coconut", RecipeIngredients = "prawn, coconut" });
            Recipes.Add(new Recipe() { RecipeId = id++, CuisineType = "1", RecipeName = "Curry Prawn", RecipeDescription = "Prawn curry", RecipeIngredients = "prawn, chilli, garlic" });
            string descriptions = "Dosa is a popular South Indian thin crepe made with fermented rice and lentil batter. Usually served with chutney. <Coconut Chutney>, <Tomato Chutney>, <Potato Masala>.\r\n\r\n" +
                "Making dosa starts by soaking rice and black gram, later they are ground to a batter which is fermented overnight. This batter is spread like a crepe ona hot griddle.";
            Recipes.Add(new Recipe() { RecipeId = id++, CuisineType = "1", RecipeName = "Dosa with onion and potato", RecipeDescription = descriptions, RecipeIngredients = "fermented rice, flour, onion, potato" });
        }
        public void AddNewRecipe(char cuisineTypeFromUser)
        {
            Recipe recipe = new Recipe();
            recipe.CuisineType = cuisineTypeFromUser.ToString();
            recipe.RecipeId = id++;
            Console.Write("Name= ");
            recipe.RecipeName = Console.ReadLine();
            Console.Write("Desc= ");
            recipe.RecipeDescription = Console.ReadLine();
            Console.Write("Ingredients= ");
            recipe.RecipeIngredients = Console.ReadLine();
            Recipes.Add(recipe);
        }

        public void ShowRecipe()
        {
            foreach (var i in Recipes)
            {
                Console.WriteLine($"ID: {i.RecipeId} | Name: {i.RecipeName} | ");
            }
        }

        public void ShowRecipeDetail(int recipeID)
        {
            Recipe recipeToShow = Recipes.Find(x => x.RecipeId == recipeID);
            if (recipeToShow != null)
            {
                int recipeCuisineType = int.Parse(recipeToShow.CuisineType);
                string cuisineTypeName = Enum.GetName(typeof(CuisineType), recipeCuisineType);
                Console.WriteLine($"Name: {recipeToShow.RecipeName}");
                Console.WriteLine($"Description: {recipeToShow.RecipeDescription}");
                Console.WriteLine($"Ingredients: {recipeToShow.RecipeIngredients}");
                Console.WriteLine($"Cuisine: {cuisineTypeName}");
            }
        }

        public void DeleteRecipe(int recipeIDToRemove)
        {
            Recipe recipeToRemove = Recipes.Find(x => x.RecipeId == recipeIDToRemove);
            if (recipeToRemove != null)
            {
                Console.WriteLine($"Deleting recipe with RecipeId = {recipeIDToRemove}");
                Recipes.Remove(recipeToRemove);
            }
            else
            {
                Console.WriteLine($"Recipe with the given ID (recipeID = {recipeIDToRemove}) not exist. ");
            }
        }
    }
}
