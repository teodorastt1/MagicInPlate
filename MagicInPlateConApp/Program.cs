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
            Console.WriteLine(" ---Magic In Plate--- \nИзтриване на рецепта\n");

            var recipes = formView.GetRecipeNames();
            var recipeIds = formView.GetRecipeId();
                if (recipes.Count == 0)
                {
                    Console.WriteLine(" Няма налични рецепти за изтриване.");
                    return;
                }

                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {recipes[i]}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Изберете рецепта за изтриване: ");
                if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > recipes.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Невалиден избор.");
                    return;
                }

                int recipeId = recipeIds[index - 1];

                try
                {
                    formView.DeleteRecipeById(recipeId);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Рецептата е изтрита успешно.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Грешка при изтриване: {ex.Message}");
                }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);

            SayGoodbyeAndReturn();
        }
        static void EditRecipe(FormView formView)
        {
            Console.Clear();
            var recipes = formView.GetRecipeNames();
            var recipeIds = formView.GetRecipeId();
            while (true)
            {
                if (recipes.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Няма налични рецепти за редакция.");
                    continue;
                }
                break;
            }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Изберете рецепта за редакция:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {recipes[i]}");
                }

                Console.Write("Вашият избор: ");
                if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > recipeIds.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
                    return;
                }
 
                int recipeId = recipeIds[index - 1];
                Console.Write("Ново име: ");
                string newName = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine(" Името не може да е празно.");
                    continue;
                }
                if (newName.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                if (!IsBulgarianText(newName))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }
                

                Console.Write("Ново описание: ");
                string newDescription = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(newDescription))
                {
                    Console.WriteLine(" Описанието не може да е празно.");
                    continue;
                }
                if (newDescription.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                if (!IsBulgarianText(newDescription))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }


                Console.Write("Ново време за приготвяне (в минути): ");
                if (!int.TryParse(Console.ReadLine(), out int newPrepTime) || newPrepTime <= 0)
                {
                    Console.WriteLine(" Невалидно време.");
                    return;
                }

            string newDifficulty;
            while (true)
            {
                Console.Write("Нова трудност (Лесно/Средно/Трудно): ");
                newDifficulty = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newDifficulty))
                {
                    Console.WriteLine(" Трудността не може да е празна.");
                    continue;
                }
                break;
            }

            string newCategory;
            while (true)
            {
                Console.Write("Категория (Предястие/Основно/Десерт):  ");
                newCategory = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newCategory))
                {
                    Console.WriteLine(" Категорията не може да е празна.");
                    continue;
                }
                break;
            }
                
            string newInstructions;
            while (true)
            {
                Console.Write("Нови инструкции: ");
                newInstructions = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newInstructions))
                {
                    Console.WriteLine(" Инструкциите не могат да са празни.");
                    continue;
                }
                break;
            }
                List<string> ingredients = new List<string>();
                List<string> quantities = new List<string>();

                Console.Write("Брой съставки: ");
                if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
                {
                    Console.WriteLine(" Невалиден брой съставки.");
                    return;
                }

                Console.WriteLine("Налични продукти:");
                foreach (var ing in formView.GetIngredientNames())
                {
                    Console.WriteLine($"- {ing}");
                }

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Съставка {i + 1}: ");
                    string ingredient = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ingredient))
                    {
                        Console.WriteLine(" Съставката не може да е празна.");
                        continue;
                    }

                    if (!formView.GetIngredientNames().Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($" Съставката \"{ingredient}\" не съществува в базата.");
                        continue;
                    }

                    Console.Write("Количество: ");
                    string quantity = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(quantity))
                    {
                        Console.WriteLine(" Количеството не може да е празно.");
                        continue;
                    }

                    ingredients.Add(ingredient);
                    quantities.Add(quantity);
                }

                try
                {
                    formView.UpdateRecipe(recipeId, newName, newDescription, newPrepTime, newDifficulty, newInstructions, newCategory, ingredients, quantities);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Рецептата е успешно редактирана.");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Грешка при редактиране: {ex.Message}");
                    
                }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);

            SayGoodbyeAndReturn();
        }

        private static void AddIngredient(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ---Magic In Plate--- \nДобавяне на продукт\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
 
                
            string name;
            while (true)
            {
                Console.Write("Въведете име на нов продукт: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Невалидно име на продукт! Моля въведете правилно име.");
                    continue;
                }
                if (name.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                if (!IsBulgarianText(name))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }

             var existingIngredients = formView.GetIngredientNames();
            while (true)
            {
                if (existingIngredients.Contains(name, StringComparer.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Продукт с това име вече съществува.");
                    continue;
                }
                break;
            }
               
            
                try
                {
                    formView.AddIngredient(name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Продуктът е добавен успешно!");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Грешка при добавяне: {ex.Message}");
                }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);

            SayGoodbyeAndReturn();
        }
        private static void AddRecipe(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ---Magic In Plate--- \nДобавяне на рецепта\n ");

            string name;
            while (true)
            {
                Console.Write("Име на рецепта: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Името на рецептата не може да бъде празно.");
                    continue;
                }
                if (name.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                if (!IsBulgarianText(name))
                {
                    Console.WriteLine("Името не трябва да съдържа английски букви.");
                    continue;
                }
                break;
            }

            string description;
            while (true)
            {
                Console.Write("Описание: ");
                description = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Описанието не може да бъде празно.");
                    continue;
                }
                if (description.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                if (!IsBulgarianText(description))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }

            int prepTime;
            while (true)
            {
                Console.Write("Време за приготвяне (в минути): ");
                if (!int.TryParse(Console.ReadLine(), out prepTime) || prepTime <= 0)
                {
                    Console.WriteLine("Невалидно време за приготвяне.");
                    continue;
                }
                break;
            }

            string difficulty;
            while (true)
            {
                Console.Write("Трудност (Лесно/Средно/Трудно): ");
                difficulty = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(difficulty))
                {
                    Console.WriteLine("Моля, въведете трудност.");
                    continue;
                }

                var diffLower = difficulty.ToLower();
                if (diffLower != "лесно" && diffLower != "средно" && diffLower != "трудно")
                {
                    Console.WriteLine("Невалидна стойност за трудност. Допустими: Лесно, Средно, Трудно.");
                    continue;
                }
                break;
            }

            string category;
            while (true)
            {
                Console.Write("Категория (Предястие/Основно/Десерт): ");
                category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Моля, въведете категория.");
                    continue;
                }

                var catLower = category.ToLower();
                if (catLower != "предястие" && catLower != "основно" && catLower != "десерт")
                {
                    Console.WriteLine("Невалидна категория. Допустими: Предястие, Основно, Десерт.");
                    continue;
                }
                break;
            }

            string instructions;
            while (true)
            {
                Console.Write("Инструкции: ");
                instructions = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(instructions))
                {
                    Console.WriteLine("Моля въведете инструкции.");
                    continue;
                }
                if (instructions.Length < 3)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 3 букви.");
                    continue;
                }
                if (!IsBulgarianText(instructions))
                {
                    Console.WriteLine("Инструкциите съдържат английски букви. Използвайте български.");
                    continue;
                }
                break;
            }

            List<string> ingredients = new List<string>();
            List<string> quantities = new List<string>();

            int count;
            while (true)
            {
                Console.Write("Брой съставки: ");
                if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    Console.WriteLine("Невалиден брой съставки.");
                    continue;
                }
                break;
            }

            List<string> availableIngredients = formView.GetIngredientNames();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nНалични продукти в базата данни:");
            Console.WriteLine("──────────────────────────────────────");
            foreach (var ingr in availableIngredients)
            {
                Console.WriteLine($"{ingr}");
            }
            Console.WriteLine("──────────────────────────────────────\n");

            for (int i = 0; i < count; i++)
            {
                string ingredient;
                while (true)
                {
                    Console.Write($"Продукт {i + 1}: ");
                    ingredient = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ingredient))
                    {
                        Console.WriteLine($"Съставка {i + 1} не може да бъде празна.");
                        continue;
                    }

                    if (!availableIngredients.Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Продуктът \"{ingredient}\" не съществува в базата данни.");
                        continue;
                    }
                    break;
                }
                ingredients.Add(ingredient);

                string quantity;
                while (true)
                {
                    Console.Write("Количество: ");
                    quantity = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(quantity))
                    {
                        Console.WriteLine("Количеството не може да бъде празно.");
                        continue;
                    }
                    break;
                }
                quantities.Add(quantity);
            }

            try
            {
                formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, ingredients, quantities);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Рецептата е добавена успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Възникна грешка при добавянето на рецептата: {ex.Message}");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);

            SayGoodbyeAndReturn();
        }

        private static void ViewRecipes(FormView formView)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ---Magic In Plate--- \nПреглед на Рецепти\n");

            var recipeIds = formView.GetRecipeId();
            var recipeNames = formView.GetRecipeNames();
            var recipeDescriptions = formView.GetRecipeDescription();
            var prepTimes = formView.GetRecipePrepTime();
            var difficulties = formView.GetRecipeDifficulty();
            var categories = formView.GetRecipeCategoryName();
            var instructions = formView.GetRecipeInstructions();

            if (recipeNames.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Няма налични рецепти.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Изберете рецепта:\n");

            for (int i = 0; i < recipeNames.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipeNames[i]}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nВашият избор: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > recipeNames.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
                Console.ResetColor();
                return;
            }

            int index = choice - 1;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{choice}] {recipeNames[index]}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Описание: {recipeDescriptions[index]}");
            Console.WriteLine($"Време за приготвяне: {prepTimes[index]} минути");
            Console.WriteLine($"Трудност: {difficulties[index]}");
            Console.WriteLine($"Категория: {categories[index]}");
            Console.WriteLine($"Инструкции: {instructions[index]}\n");

            var ingredients = formView.GetIngredientsForRecipe(recipeIds[index]);
            var quantities = formView.GetIngredientQuantityForRecipe(recipeIds[index]);

            Console.WriteLine("Съставки:");
            for (int j = 0; j < ingredients.Count; j++)
            {
                Console.WriteLine($" - {ingredients[j]}: {quantities[j]}");
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);

            SayGoodbyeAndReturn();
        }

        private static bool IsBulgarianText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char c in input)
            {
                if (!((c >= 'А' && c <= 'я') || c == ' ' || c == ',' || c == '.' || c == '-' || c == '!' || c == '?' || c == 'ъ' || c == 'ь' || c == 'щ' || c == 'ю' || c == 'я'))
                    return false;
            }
            return true;
        }
        private static void SayGoodbyeAndReturn()
        {
            Console.Clear();

            // Set up colors and styles for the goodbye message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║                                          ║");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("          Благодарим Ви, че използвахте     ");
            Console.WriteLine("                 Magic In Plate!            ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("               До скоро виждане!            ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("║                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Натиснете произволен клавиш, за да се върнете към менюто...");

            Console.ResetColor();
            Console.ReadKey(true);

            Console.Clear();
        }

    }
}
    

