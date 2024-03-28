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

        int highestId = 1000;
        public void CreateStartingList()
        {
            Recipes.Add(new Recipe() { RecipeId = highestId++, CuisineType = "1", RecipeTitle = "Butter chicken", RecipeDescription = "Chicken curry masala", RecipeIngredients = "chicken, onion, potato, cream, garlic, ginger, indian spices" });
            Recipes.Add(new Recipe() { RecipeId = highestId++, CuisineType = "1", RecipeTitle = "Naan garlic", RecipeDescription = "Prawn curry coconut", RecipeIngredients = "prawn, coconut" });
            Recipes.Add(new Recipe() { RecipeId = highestId++, CuisineType = "1", RecipeTitle = "Curry Prawn", RecipeDescription = "Prawn curry", RecipeIngredients = "prawn, chilli, garlic" });
            string descriptions = "Dosa is a popular South Indian thin crepe made with fermented rice and lentil batter. Usually served with chutney. <Coconut Chutney>, <Tomato Chutney>, <Potato Masala>.\r\n\r\n" +
                "Making dosa starts by soaking rice and black gram, later they are ground to a batter which is fermented overnight. This batter is spread like a crepe ona hot griddle.";
            Recipes.Add(new Recipe() { RecipeId = highestId++, CuisineType = "1", RecipeTitle = "Dosa with onion and potato", RecipeDescription = descriptions, RecipeIngredients = "fermented rice, flour, onion, potato" });
        }
        public void AddNewRecipe(char cuisineTypeFromUser)
        {
            highestId = Recipes.Any() ? Recipes.Max(x => x.RecipeId) : 1;
            Recipe recipe = new Recipe();
            recipe.CuisineType = cuisineTypeFromUser.ToString();
            recipe.RecipeId = highestId++;
            Console.Write("Title= ");
            recipe.RecipeTitle = Console.ReadLine();
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
                Console.WriteLine($"ID: {i.RecipeId} | Title: {i.RecipeTitle} | ");
            }
        }

        public void ShowRecipeDetail(int recipeID)
        {
            Recipe recipeToShow = Recipes.Find(x => x.RecipeId == recipeID);
            if (recipeToShow != null)
            {
                int recipeCuisineType = int.Parse(recipeToShow.CuisineType);
                string cuisineTypeName = Enum.GetName(typeof(CuisineType), recipeCuisineType);
                Console.WriteLine($"Name: {recipeToShow.RecipeTitle}");
                Console.WriteLine($"Description: {recipeToShow.RecipeDescription}");
                Console.WriteLine($"Ingredients: {recipeToShow.RecipeIngredients}");
                Console.WriteLine($"Cuisine: {cuisineTypeName}");
            }
        }

        public void DeleteRecipeById(int recipeIDToRemove)
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

        public void DeleteRecipeByName(string recipeTitleToRemove)
        {
            List<Recipe> recipeToRemove = Recipes.FindAll(x => x.RecipeTitle.Contains("recipeNameToRemove"));
            if (recipeToRemove != null)
            {
                foreach (Recipe i in recipeToRemove)
                {
                    Console.WriteLine($"Deleting recipe with RecipeId: {i.RecipeId} Name: {i.RecipeTitle}");
                    Recipes.Remove(i);
                }
            }
            else
            {
                Console.WriteLine($"Any recipe with Title contains the given phrase: \"{recipeTitleToRemove}\" not exist. ");
            }
        }
    }
}
