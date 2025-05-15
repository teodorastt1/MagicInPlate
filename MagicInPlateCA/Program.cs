using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicInPlateCA
{

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "🍽 PumiikaVChiniika Console Menu 🍽";
            Console.ForegroundColor = ConsoleColor.Cyan;


            while (true)
            {
                ShowHeader("PumiikaVChiniika - Console Menu");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. 📝 Show All Recipes");
                Console.WriteLine("2. ➕ Add New Ingredient");
                Console.WriteLine("3. ❌ Delete Recipe by ID");
                Console.WriteLine("4. 📜 Show All Ingredients");
                Console.WriteLine("5. 🚪 Exit");
                Console.Write("\n👉 Select an option (1-5): ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                        ShowHeader("📖 All Recipes");
                        var recipes = formView.GetRecipeNames();
                        foreach (var recipe in recipes)
                        {
                            Console.WriteLine($"- {recipe}");
                        }
                        BreakPrompt();
                        break;

                    case "2":
                        ShowHeader("➕ Add Ingredient");
                        Console.Write("Enter new ingredient name: ");
                        string name = Console.ReadLine();
                        formView.AddIngredient(name);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nIngredient '{name}' added successfully!");
                        BreakPrompt();
                        break;

                    case "3":
                        ShowHeader("❌ Delete Recipe");
                        var ids = formView.GetRecipeId();
                        var names = formView.GetRecipeNames();
                        for (int i = 0; i < names.Count; i++)
                        {
                            Console.WriteLine($"{ids[i]}: {names[i]}");
                        }
                        Console.Write("\nEnter Recipe ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int recipeId))
                        {
                            formView.DeleteRecipeById(recipeId);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nRecipe deleted successfully.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID!");
                        }
                        BreakPrompt();
                        break;

                    case "4":
                        ShowHeader("📜 All Ingredients");
                        var ingredients = formView.GetAllIngredients();
                        foreach (var ing in ingredients)
                        {
                            Console.WriteLine($"- {ing}");
                        }
                        BreakPrompt();
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nThank you for using PumiikaVChiniika! Goodbye 👋");
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option! Please try again.");
                        BreakPrompt();
                        break;
                }
            }
        }

        static void ShowHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==============================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"            {title}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==============================================\n");
        }

        static void BreakPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    } 
}
    

