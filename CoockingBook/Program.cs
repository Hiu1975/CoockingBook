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
            bool showSubMenuRun = true;

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
                    Char cuisineTypeFromUser = CheckKey.CheckPressedKey("Yours choice: ", new char[] { '1', '2', '3', '4', '5', '6' });
                    recipeService.AddNewRecipe(cuisineTypeFromUser);
                    break;
                case '2':
                case 'D':
                    showSubMenuRun = true;
                    while (showSubMenuRun)
                    {
                       // Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Recipes list.");
                        Console.WriteLine();
                        recipeService.ShowRecipe();
                        Console.WriteLine();
                        Console.WriteLine("1. Delete - by recipe (I)D.");
                        Console.WriteLine("2. Delete - by recipe (T)itle.");
                        Console.WriteLine("3. Back to (M)ainMenu.");
                        Console.WriteLine();
                        Char keyFromUserSubMenu = CheckKey.CheckPressedKey(" Yours choice: ", new Char[] { 'I', 'T', 'M', '1', '2', '3' });
                        if (keyFromUserSubMenu == '1' || Char.ToUpper(keyFromUserSubMenu) == 'I')
                        {
                            Console.Write("Enter recipe ID you want to delete: ");
                            recipeService.DeleteRecipeById(int.Parse(Console.ReadLine()));
                        }
                        else if (keyFromUserSubMenu == '2' || Char.ToUpper(keyFromUserSubMenu) == 'T')
                        {
                            Console.Write("Enter the title of the recipe (or part of title) you want to remove: ");
                            recipeService.DeleteRecipeByName(Console.ReadLine());
                        }
                        else if (keyFromUserSubMenu == '3' || Char.ToUpper(keyFromUserSubMenu) == 'M')
                        {
                            Console.Clear();
                            showSubMenuRun = false;
                        }
                        else
                        {
                            Console.Beep();
                            Console.WriteLine("choose (I/T/M): ");
                        }
                    }
                    break;
                case '3':
                case 'S':
                    showSubMenuRun = true;
                    while (showSubMenuRun)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Recipes list.");
                        Console.WriteLine();
                        recipeService.ShowRecipe();
                        Console.WriteLine();
                        Console.WriteLine("1. Show (D)etails of recipe - by recipe Id.");
                        Console.WriteLine("2. Back to (M)ainMenu.");
                        Console.WriteLine();
                        Char keyFromUserSubMenu = CheckKey.CheckPressedKey(" Yours choice (D - details, M - Main Menu): ", new Char[] { 'D', 'M', '1', '2' });
                        if (keyFromUserSubMenu == '1' || Char.ToUpper(keyFromUserSubMenu) == 'D')
                        {
                            Console.Write("Enter recipe ID to see all details: ");
                            int recipeID = int.Parse(Console.ReadLine());
                            Console.Clear();
                            recipeService.ShowRecipeDetail(recipeID);
                        }
                        else if (keyFromUserSubMenu == '2' || Char.ToUpper(keyFromUserSubMenu) == 'M')
                        {
                            Console.Clear();
                            showSubMenuRun = false;
                        }
                        else
                        {
                            Console.Beep();
                            Console.WriteLine("choose (D/M): ");
                        }
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