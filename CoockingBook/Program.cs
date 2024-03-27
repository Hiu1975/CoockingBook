// 5. Wyświetlenie przepisu po nazwie, składniku
// 6. Wyświetlenie przpisów według filtru, np.Id typu kuchnii, dania
// 7. Edycja przepisu.
// 8. Walidacja danych.

namespace CoockingBook;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Welcome to the 'Best Cookbook' app.");
        RecipeService recipeService = new RecipeService();
        recipeService.CreateStartingList();
        bool keepRun = true;

        while (keepRun)
        {
            Console.WriteLine();
            Console.WriteLine("Select the action you want to do.");
            Console.WriteLine();
            Console.WriteLine("1. (A)dd new recipe.");
            Console.WriteLine("2. (D)elete recipe.");
            Console.WriteLine("3. (S)how recipes list.");
            Console.WriteLine("4. (Q)uit the app.");
            Console.WriteLine();

            Char keyFromUser = CheckKey.CheckPressedKey(" Yours choice: ", new Char[] { 'A', 'D', 'S', 'Q', '1', '2', '3', '4' });

            switch (Char.ToUpper(keyFromUser))
            {
                case '1':
                case 'A':
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Adding a new recipe.");
                    Console.WriteLine();
                    Console.Write("Choose cuisine type.");
                    Console.WriteLine();
                    foreach (var enumCuisineType in Enum.GetValues(typeof(CuisineType)))
                    {
                        Console.WriteLine($"{(int)enumCuisineType}. {enumCuisineType.ToString()}");
                    }
                    Console.WriteLine();
                    break;
                case '2':
                case 'D':
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Deleting a recipe.");
                    Console.WriteLine();
                    Console.Write("Enter recipe ID you want to delete: ");
                    recipeService.DeleteRecipe(int.Parse(Console.ReadLine()));
                    break;
                case '3':
                case 'S':
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Showing a recipes list.");
                    Console.WriteLine();
                    recipeService.ShowRecipe();
                    Console.WriteLine();
                    Console.WriteLine("1. Show details of recipe - choose by recipe(I)D.");
                    Console.WriteLine("2. Back to (M)ainMenu.");
                    Console.WriteLine();
                    Char keyFromUserSubMenu = CheckKey.CheckPressedKey(" Yours choice (D - details, M - Main Menu): ", new Char[] { 'D', 'M', '1', '2' });
                    if (keyFromUserSubMenu == '1' || Char.ToUpper(keyFromUserSubMenu) == 'D')
                    {
                        Console.WriteLine("enter ID: ");
                        int recipeID = int.Parse(Console.ReadLine());
                        recipeService.ShowRecipeDetail(recipeID);
                    }
                    break;
                case '4':
                case 'Q':
                    Console.WriteLine();
                    Console.WriteLine("Exiting");
                    keepRun = false;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("You pressed the wrong key.");
                    break;
            }
        }
    }
}