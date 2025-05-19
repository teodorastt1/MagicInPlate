using PumiikaVChiniika;
using System.Linq.Expressions;
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
            throw new NotImplementedException();
        }

        private static void EditRecipe(FormView formView)
        {
            throw new NotImplementedException();
        }

        private static void AddIngredient(FormView formView)
        {
            throw new NotImplementedException();
        }

        private static void AddRecipe(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Име на рецепта: ");
            string name = Console.ReadLine();

            Console.Write("Описание: ");
            string description = Console.ReadLine();

            Console.Write("Време за приготвяне (в минути): ");
            int prepTime = int.Parse(Console.ReadLine());

            Console.Write("Трудност (Лесно/Средно/Трудно): ");
            string difficulty = Console.ReadLine();

            Console.Write("Категория (Предястие/Основно/Десерт): ");
            string category = Console.ReadLine();

            Console.Write("Инструкции: ");
            string instructions = Console.ReadLine();

            List<string> ingredients = new();
            List<string> quantities = new();

            Console.Write("Брой съставки: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Продукт {i + 1}: ");
                ingredients.Add(Console.ReadLine());

                Console.Write("Количество: ");
                quantities.Add(Console.ReadLine());
            }

            formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, ingredients, quantities);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Рецептата е добавена успешно!");
        }



        private static void ViewRecipes(FormView formView)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Име на рецепта: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError("Името на рецептата не може да бъде празно.");
                return;
            }

            Console.Write("Описание: ");
            string description = Console.ReadLine();

            Console.Write("Време за приготвяне (в минути): ");
            if (!int.TryParse(Console.ReadLine(), out int prepTime) || prepTime <= 0)
            {
                ShowError("Невалидно време за приготвяне.");
                return;
            }

            Console.Write("Трудност (Лесно/Средно/Трудно): ");
            string difficulty = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(difficulty))
            {
                ShowError("Моля, въведете трудност.");
                return;
            }

            Console.Write("Категория (Предястие/Основно/Десерт): ");
            string category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(category))
            {
                ShowError("Моля, въведете категория.");
                return;
            }

            Console.Write("Инструкции: ");
            string instructions = Console.ReadLine();

            List<string> ingredients = new();
            List<string> quantities = new();

            Console.Write("Брой съставки: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                ShowError("Невалиден брой съставки.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Продукт {i + 1}: ");
                string ingredient = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    ShowError($"Съставка №{i + 1} не може да бъде празна.");
                    return;
                }

                if (!formView.GetIngredientNames().Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                {
                    ShowError($" Продуктът \"{ingredient}\" не съществува в базата данни.");
                    return;
                }

                ingredients.Add(ingredient);

                Console.Write("Количество: ");
                string quantity = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    ShowError("Количеството не може да бъде празно.");
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
                ShowError($"Възникна грешка при добавянето на рецептата: {ex.Message}");
            }
        }


        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
    

