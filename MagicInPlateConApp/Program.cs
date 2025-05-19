using PumiikaVChiniika;
using System.Linq.Expressions;
using System.Globalization;
namespace MagicInPlateConApp

{
    internal class Program
    {
        static void Main(string[] args)
        {
            FormView formView = new FormView();
            Console.Title = " Magic In Plate ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Добре дошли в\n" +
                " ---Magic In Plate--- \n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Моля, изберете опция:");
                Console.WriteLine("1.  Преглед на рецепти");
                Console.WriteLine("2.  Добавяне на рецепта");
                Console.WriteLine("3.  Добавяне на продукт");
                Console.WriteLine("4.  Промяна на рецепта");
                Console.WriteLine("5.  Изтриване на рецепта");
                Console.WriteLine("0.    Изход");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Избор: ");
                string choice = Console.ReadLine();
                Console.Beep(400, 300);

                Console.ResetColor();
                
                Console.WriteLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewRecipes(formView);
                        break;
                    case "2":
                        AddRecipe(formView);
                        break;
                    case "3":
                        AddIngredient(formView);
                        break;
                    case "4":
                        EditRecipe(formView);
                        break;
                    case "5":
                        DeleteRecipe(formView);
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("До скоро!");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Невалиден избор. Опитайте отново.");
                        break;
                }

                Console.WriteLine("\nНатиснете Enter за продължение...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void DeleteRecipe(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---Magic In Plate--- \n" +
                "Изтриване на рецепта\n ");
            var recipes = formView.GetRecipeNames();
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipes[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Изберете рецепта за изтриване: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < recipes.Count)
            {
                int recipeId = formView.GetRecipeId()[index];
                formView.DeleteRecipeById(recipeId);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Рецептата е изтрита успешно.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
            }
        }

        private static void EditRecipe(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ---Magic In Plate--- \n" +
                "Промяна на рецепта\n ");
            var recipes = formView.GetRecipeNames();
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipes[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Изберете рецепта за редакция: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < recipes.Count)
            {
                string name = formView.GetRecipeNames()[index];
                int recipeId = formView.GetRecipeId()[index];

                Console.Write("Ново име: ");
                string newName = Console.ReadLine();
                Console.Write("Ново описание: ");
                string newDescription = Console.ReadLine();
                Console.Write("Ново време за приготвяне: ");
                string newTime = Console.ReadLine();
                Console.Write("Нова трудност: ");
                string newDifficulty = Console.ReadLine();
                Console.Write("Нова категория: ");
                string newCategory = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Промените са приложени (фалшиво за сега - нужни са реални методи за Update).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
            }
        }

        private static void AddIngredient(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ---Magic In Plate--- \n" +
                "Добавяне на продукт\n ");
            static void AddIngredient(FormView formView)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Въведете име на нов продукт: ");
                string name = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(name))
                {
                    formView.AddIngredient(name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Продуктът е добавен успешно!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невалидно име на продукт! Моля въведете правилно име.");
                }
            }
        }

        private static void AddRecipe(FormView formView)
        {
             Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ---Magic In Plate--- \n" +
                "Добавяне на рецепта\n ");

            Console.Write("Име на рецепта: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Името на рецептата не може да бъде празно.");
                return;
            }

            Console.Write("Описание: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Името на описанието не може да бъде празно.");
                return;
            }

            Console.Write("Време за приготвяне (в минути): ");
            if (!int.TryParse(Console.ReadLine(), out int prepTime) || prepTime <= 0)
            {
                Console.WriteLine("Невалидно време за приготвяне.");
                return;
            }

            Console.Write("Трудност (Лесно/Средно/Трудно): ");
            string difficulty = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(difficulty))
            {
                Console.WriteLine("Моля, въведете трудност.");
                return;
            }

            Console.Write("Категория (Предястие/Основно/Десерт): ");
            string category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Моля, въведете категория.");
                return;
            }

            Console.Write("Инструкции: ");
            string instructions = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(instructions))
            {
                Console.WriteLine("Моля въведете инструкции.");
                return;
            }

            List<string> ingredients = new();
            List<string> quantities = new();

            Console.Write("Брой съставки: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Невалиден брой съставки.");
                return;
            }

            List<string> availableIngredients;
            try
            {
                availableIngredients = formView.GetIngredientNames();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n Налични продукти в базата данни:");
                Console.WriteLine("──────────────────────────────────────");
                foreach (var ingr in availableIngredients)
                {
                    Console.WriteLine($"• {ingr}");
                }
                Console.WriteLine("──────────────────────────────────────\n");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Неуспешно зареждане на съставките от базата данни.");
                Console.WriteLine($"[Техническа грешка]: {ex.Message}");
                return;
            }


            for (int i = 0; i < count; i++)
            {
                Console.Write($"Продукт {i + 1}: ");
                string ingredient = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    Console.WriteLine($"Съставка №{i + 1} не може да бъде празна.");
                    return;
                }

                if (!formView.GetIngredientNames().Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" Продуктът \"{ingredient}\" не съществува в базата данни.");
                    ingredients.Add(ingredient);
                    return;
                }

               

                Console.Write("Количество: ");
                string quantity = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    Console.WriteLine("Количеството не може да бъде празно.");
                    return;
                }

                quantities.Add(quantity);
            }

            try
            {
                formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, ingredients, quantities);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Рецептата е добавена успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Възникна грешка при добавянето на рецептата: {ex.Message}");
            }
        }



        private static void ViewRecipes(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(  " ---Magic In Plate--- \n" +
                "Преглед на Рецепти\n ");
           
            var recipeNames = formView.GetRecipeNames();
            var recipeDescriptions = formView.GetRecipeDescription();
            var prepTimes = formView.GetRecipePrepTime();
            var difficulties = formView.GetRecipeDifficulty();
            var categories = formView.GetRecipeCategoryName();
            var instructions = formView.GetRecipeInstructions();

            for (int i = 0; i < recipeNames.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{i + 1}] {recipeNames[i]}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Описание: {recipeDescriptions[i]}");
                Console.WriteLine($"Време за приготвяне: {prepTimes[i]} минути");
                Console.WriteLine($"Трудност: {difficulties[i]}");
                Console.WriteLine($"Категория: {categories[i]}");
                Console.WriteLine($"Инструкции: {instructions[i]}\n");

                var ingredients = formView.GetIngredientsForRecipe(formView.GetRecipeId()[i]);
                var quantities = formView.GetIngredientQuantityForRecipe(formView.GetRecipeId()[i]);

                Console.WriteLine("Съставки:");
                for (int j = 0; j < ingredients.Count; j++)
                {
                    Console.WriteLine($" - {ingredients[j]}: {quantities[j]}");
                }
                Console.WriteLine(new string('-', 40));
            }

        }


        //static void ShowError(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine(message);
        //    Console.ResetColor();
        //}
    }
}
    

