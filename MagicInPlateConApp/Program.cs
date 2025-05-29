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

        static void EditRecipe(FormView formView)
        {
            Console.Clear();
            var recipes = formView.GetRecipeNames();
            var recipeIds = formView.GetRecipeId();

            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Няма налични рецепти за редакция.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Изберете рецепта за редакция:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipes[i]}");
            }

            Console.Write("Вашият избор: ");
            int index = int.Parse(Console.ReadLine());
            

            int recipeId = recipeIds[index - 1];

            Console.Write("Ново име: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine(" Името не може да е празно.");
                return;
            }

            Console.Write("Ново описание: ");
            string newDescription = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                Console.WriteLine(" Описанието не може да е празно.");
                return;
            }

            Console.Write("Ново време за приготвяне (в минути): ");
            if (!int.TryParse(Console.ReadLine(), out int newPrepTime) || newPrepTime <= 0)
            {
                Console.WriteLine(" Невалидно време.");
                return;
            }

            Console.Write("Нова трудност (Лесно/Средно/Трудно): ");
            string newDifficulty = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDifficulty))
            {
                Console.WriteLine(" Трудността не може да е празна.");
                return;
            }

            Console.Write("Категория (Предястие/Основно/Десерт):  ");
            string newCategory = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newCategory))
            {
                Console.WriteLine(" Категорията не може да е празна.");
                return;
            }

            Console.Write("Нови инструкции: ");
            string newInstructions = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newInstructions))
            {
                Console.WriteLine(" Инструкциите не могат да са празни.");
                return;
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
                    return;
                }

                if (!formView.GetIngredientNames().Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                {  
                    Console.WriteLine($" Съставката \"{ingredient}\" не съществува в базата.");
                    return;
                }

                Console.Write("Количество: ");
                string quantity = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    Console.WriteLine(" Количеството не може да е празно.");
                    return;
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
        }


        private static void AddIngredient(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ---Magic In Plate--- \n" +
                "Добавяне на продукт\n ");



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
            }

            Console.Write("Трудност (Лесно/Средно/Трудно): ");
            string difficulty = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(difficulty))
            {
                Console.WriteLine("Моля, въведете трудност.");
            }

            Console.Write("Категория (Предястие/Основно/Десерт): ");
            string category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Моля, въведете категория.");
            }

            Console.Write("Инструкции: ");
            string instructions = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(instructions))
            {
                Console.WriteLine("Моля въведете инструкции.");
            }

            List<string> ingredients = new List<string>();
            List<string> quantities = new List<string>();

            Console.Write("Брой съставки: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Невалиден брой съставки.");
            }

            List<string> availableIngredients;
            
                availableIngredients = formView.GetIngredientNames();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n Налични продукти в базата данни:");
                Console.WriteLine("──────────────────────────────────────");
                foreach (var ingr in availableIngredients)
                {
                    Console.WriteLine($"{ingr}");
                }
                Console.WriteLine("──────────────────────────────────────\n");
            


            for (int i = 0; i < count; i++)
            {
                Console.Write($"Продукт {i + 1}: ");
                string ingredient = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    Console.WriteLine($"Съставка {i + 1} не може да бъде празна.");

                }

                if (!formView.GetIngredientNames().Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" Продуктът \"{ingredient}\" не съществува в базата данни.");
                }
                ingredients.Add(ingredient);


                Console.Write("Количество: ");
                string quantity = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    Console.WriteLine("Количеството не може да бъде празно.");
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

        }

    }
}
    

