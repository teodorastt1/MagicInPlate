using PumiikaVChiniika.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInPlateConApp.ConsoleView
{
    internal class ConsoleViews
    {
        // Метод ShowMenu показва главното меню на приложението и обработва избора на потребителя
        public void ShowMenu()
        {
            // Създаване на обект от RecipeServices, който предоставя функционалностите за работа с рецепти
            RecipeServices formView = new RecipeServices();

            // Задаване на заглавие на прозореца на конзолата
            Console.Title = " Magic In Plate ";

            // Промяна на цвета на текста в конзолата за приветствието
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Добре дошли в\n" +
                " ---Magic In Plate--- \n");

            // Основен цикъл, който ще се изпълнява, докато потребителят не избере "0" (Изход)
            while (true)
            {
                // Промяна на цвета на текста за менюто
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Показване на менюто с опции
                Console.WriteLine("Моля, изберете опция:");
                Console.WriteLine("1.  Преглед на рецепти");
                Console.WriteLine("2.  Добавяне на рецепта");
                Console.WriteLine("3.  Добавяне на продукт");
                Console.WriteLine("4.  Промяна на рецепта");
                Console.WriteLine("5.  Изтриване на рецепта");
                Console.WriteLine("0.    Изход");

                // Промяна на цвета на текста за подсказката за избор
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Избор: ");

                // Прочитане на избора на потребителя
                string choice = Console.ReadLine();

                // Връщане на цветовете по подразбиране
                Console.ResetColor();

                // Изчистване на конзолата и добавяне на празен ред за по-добра четливост
                Console.WriteLine();
                Console.Clear();

                // Проверка на избора на потребителя чрез switch
                switch (choice)
                {
                    case "1":
                        // Потребителят е избрал "Преглед на рецепти"
                        ViewRecipes(formView);
                        break;
                    case "2":
                        // Потребителят е избрал "Добавяне на рецепта"
                        AddRecipe(formView);
                        break;
                    case "3":
                        // Потребителят е избрал "Добавяне на продукт"
                        AddIngredient(formView);
                        break;
                    case "4":
                        // Потребителят е избрал "Промяна на рецепта"
                        EditRecipe(formView);
                        break;
                    case "5":
                        // Потребителят е избрал "Изтриване на рецепта"
                        DeleteRecipe(formView);
                        break;
                    case "0":
                        // Потребителят е избрал "Изход" - прекратяване на цикъла и метода
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("До скоро!");
                        return;
                    default:
                        // Потребителят е въвел невалиден избор
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Невалиден избор. Опитайте отново.");
                        break;
                }
            }
        }

        // Метод за изтриване на рецепта
        private static void DeleteRecipe(RecipeServices formView)
        {
            // Задаване на цвят на текста за заглавието и изписването на заглавието
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ---Magic In Plate--- \nИзтриване на рецепта\n");
            // Взема имената и ID-тата на рецептите от RecipeServices
            var recipes = formView.GetRecipeNames();
            var recipeIds = formView.GetRecipeId();
            //Проверка дали има налични рецепти за изтриване
            if (recipes.Count == 0)
            {
                Console.WriteLine(" Няма налични рецепти за изтриване.");
                return;
            }
            //Изписване на списък с рецепти за изтриване
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipes[i]}");
            }
            // Промяна на цвета на текста за подсказката за избор
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Изберете рецепта за изтриване: ");
            // Прочитане на избора на потребителя и проверка дали е валиден
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > recipes.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
                return;
            }
            // Вземане на ID-то на избраната рецепта
            int recipeId = recipeIds[index - 1];
            //Опит за изтриване на рецептата чрез RecipeServices 
            try
            {
                formView.DeleteRecipeById(recipeId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Рецептата е изтрита успешно.");
            }
            // Хващане на изключение при грешка при изтриване
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Грешка при изтриване: {ex.Message}");
            }
            // Промяна на цвета на текста за подсказката за продължаване
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ResetColor();
            Console.ReadKey(true);
            // Извикване на метода SayGoodbyeAndReturn за изписване на съобщение и връщане към главното меню
            SayGoodbyeAndReturn();
        }
        // Метод за редактиране на рецепта
        static void EditRecipe(RecipeServices formView)
        {
            //Изчистване на конзолата
            Console.Clear();
            // Взема имената и ID-тата на рецептите от RecipeServices
            
            var recipes = formView.GetRecipeNames();
            var recipeIds = formView.GetRecipeId();
            //Проверка дали има налични рецепти за редакция
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
            // Изписване на списък с рецепти за редакция
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipes[i]}");
            }

            Console.Write("Вашият избор: ");
            // Прочитане на избора на потребителя и проверка дали е валиден
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > recipeIds.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
                return;
            }
            // Вземане на текущите данни за рецептата, която ще се редактира
            int recipeId = recipeIds[index - 1];
            string currentName = recipes[index - 1];
            string currentDescription = formView.GetRecipeDescription()[index - 1];
            int currentPrepTime = formView.GetRecipePrepTime()[index - 1];
            string currentDifficulty = formView.GetRecipeDifficulty()[index - 1];
            string currentCategory = formView.GetRecipeCategoryName()[index - 1];
            string currentInstructions = formView.GetRecipeInstructions()[index - 1];

            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Редактирате рецепта: {currentName}");
            Console.WriteLine("────────────────────────────────────\n");
            Console.ResetColor();

            string newName;
            // Цикъл за въвеждане на ново име на рецептата
            while (true)
            {
                Console.Write($"Ново име (оставете празно за \"{currentName}\"): ");
                newName = Console.ReadLine();
                // Проверка дали новото име е празно и ако е, се използва текущото име
                if (string.IsNullOrWhiteSpace(newName)) newName = currentName;
                // Проверка дали новото име е валидно
                if (newName.Length < 2)
                {
                    Console.WriteLine("Името трябва да съдържа поне 2 букви.");
                    continue;
                }
                // Проверка дали новото име съдържа само български букви
                if (!IsBulgarianText(newName))
                {
                    Console.WriteLine("Използвайте само български букви.");
                    continue;
                }
                // Проверка дали новото име вече съществува в базата данни
                if (newName != currentName && formView.RecipeExists(newName))
                {
                    Console.WriteLine("Това име вече съществува.");
                    continue;
                }
                break;
            }


            // Цикъл за въвеждане на ново описание на рецептатач
            string newDescription;
            while (true)
            {
                Console.Write($"Ново описание (оставете празно за \"{currentDescription}\"): ");
                newDescription = Console.ReadLine();
                // Проверка дали новото описание е празно и ако е, се използва текущото описание
                if (string.IsNullOrWhiteSpace(newDescription)) newDescription = currentDescription;
                // Проверка дали новото описание е валидно
                if (newDescription.Length < 2)
                {
                    Console.WriteLine("Описанието трябва да съдържа поне 2 букви.");
                    continue;
                }
                // Проверка дали новото описание съдържа само български букви
                if (!IsBulgarianText(newDescription))
                {
                    Console.WriteLine("Използвайте само български букви.");
                    continue;
                }
                break;
            }

            Console.Write($"Ново време за приготвяне (в минути, текущо: {currentPrepTime}): ");
            string prepInput = Console.ReadLine();
            int newPrepTime = currentPrepTime;
            // Проверка дали новото време за приготвяне е валидно
            if (!string.IsNullOrWhiteSpace(prepInput))
            {
                if (!int.TryParse(prepInput, out newPrepTime) || newPrepTime <= 0)
                {
                    Console.WriteLine("Невалидно време.");
                    return;
                }
            }

            string newDifficulty;
            // Цикъл за въвеждане на нова трудност на рецептата
            while (true)
            {
                Console.Write($"Трудност (Лесно/Средно/Трудно, текуща: {currentDifficulty}): ");
                newDifficulty = Console.ReadLine();
                // Проверка дали новата трудност е празна и ако е, се използва текущата трудност
                if (string.IsNullOrWhiteSpace(newDifficulty)) newDifficulty = currentDifficulty;

                var diffLower = newDifficulty.ToLower();
                // Проверка дали новата трудност е валидна
                if (diffLower != "лесно" && diffLower != "средно" && diffLower != "трудно")
                {
                    Console.WriteLine("Невалидна стойност. Допустими: Лесно, Средно, Трудно.");
                    continue;
                }
                break;
            }

            string newCategory;
            // Цикъл за въвеждане на нова категория на рецептата
            while (true)
            {
                Console.Write($"Категория (Предястие/Основно/Десерт, текуща: {currentCategory}): ");
                newCategory = Console.ReadLine();
                // Проверка дали новата категория е празна и ако е, се използва текущата категория
                if (string.IsNullOrWhiteSpace(newCategory)) newCategory = currentCategory;

                var catLower = newCategory.ToLower();
                // Проверка дали новата категория е валидна
                if (catLower != "предястие" && catLower != "основно" && catLower != "десерт")
                {
                    Console.WriteLine("Невалидна категория. Допустими: Предястие, Основно, Десерт.");
                    continue;
                }
                break;
            }

            string newInstructions;
            // Цикъл за въвеждане на нови инструкции за рецептата
            while (true)
            {
                Console.Write("Нови инструкции: ");
                newInstructions = Console.ReadLine();
                // Проверка дали новите инструкции са празни и ако са, се използват текущите инструкции
                if (string.IsNullOrWhiteSpace(newInstructions))
                {
                    Console.WriteLine(" Инструкциите не могат да са празни.");
                    continue;
                }
                // Проверка дали новите инструкции са валидни
                if (!IsBulgarianText(newDescription))
                {
                    Console.WriteLine("Използвайте само български букви.");
                    continue;
                }
                break;
            }
            // Списъци за съставките и количествата
            List<string> ingredients = new List<string>();
            List<string> quantities = new List<string>();

            Console.Write("Брой съставки: ");
            // Прочитане на броя съставки и проверка дали е валиден
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine(" Невалиден брой съставки.");
                return;
            }

            var availableIngredients = formView.GetIngredientNames();

            Console.WriteLine("\nНалични продукти:");
            // Изписване на наличните продукти в базата данни
            for (int i = 0; i < availableIngredients.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {availableIngredients[i]}");
            }
            //Избиране на съставки от потребителя
            for (int i = 0; i < count; i++)
            {
                Console.Write($"\nСъставка {i + 1} (въведете индекс): ");
                //Прочитане на индекса на съставката и проверка дали е валиден
                if (!int.TryParse(Console.ReadLine(), out int ingIndex) || ingIndex < 1 || ingIndex > availableIngredients.Count)
                {
                    Console.WriteLine(" Невалиден индекс.");
                    i--;
                    continue;
                }

                string ingredient = availableIngredients[ingIndex - 1];

                Console.Write("Количество: ");
                string quantity = Console.ReadLine();
                // Проверка дали количеството е празно
                if (string.IsNullOrWhiteSpace(quantity))
                {
                    Console.WriteLine(" Количеството не може да е празно.");
                    i--;
                    continue;
                }
                // Добавяне на съставката и количеството в съответните списъци
                ingredients.Add(ingredient);
                quantities.Add(quantity);
            }

            // Опит за редактиране на рецептата чрез RecipeServices
            try
            {
                formView.UpdateRecipe(recipeId, newName, newDescription, newPrepTime, newDifficulty, newInstructions, newCategory, ingredients, quantities);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Рецептата е успешно редактирана.");

            }
            // Хващане на изключение при грешка при редактиране
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
        // Метод за добавяне на нов продукт
        private static void AddIngredient(RecipeServices formView)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ---Magic In Plate--- \nДобавяне на продукт\n");

            Console.ForegroundColor = ConsoleColor.Yellow;


            string name;
            /// Цикъл за въвеждане на име на нов продукт
            while (true)
            {
                Console.Write("Въведете име на нов продукт: ");
                name = Console.ReadLine();
                // Проверка дали името е празно или съдържа само празни символи
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Невалидно име на продукт! Моля въведете правилно име.");
                    continue;
                }
                // Проверка дали името е по-кратко от 2 символа
                if (name.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                // Проверка дали името съдържа само български букви
                if (!IsBulgarianText(name))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }
            /// Проверка дали продуктът вече съществува в базата данни
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

            // Цикъл за въвеждане на количество на продукта
            try
            {
                formView.AddIngredient(name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Продуктът е добавен успешно!");
            }
            // Хващане на изключение при грешка при добавяне на продукта
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
        // Метод за добавяне на нова рецептач
        private static void AddRecipe(RecipeServices formView)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ---Magic In Plate--- \nДобавяне на рецепта\n ");

            string name;
            // Цикъл за въвеждане на име на нова рецепта
            while (true)
            {
                Console.Write("Име на рецепта: ");
                name = Console.ReadLine();
                // Проверка дали името е празно или съдържа само празни символи 
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Името на рецептата не може да бъде празно.");
                    continue;
                }
                // Проверка дали името е по-кратко от 2 символа
                if (name.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                // Проверка дали името съдържа само български букви
                if (!IsBulgarianText(name))
                {
                    Console.WriteLine("Името не трябва да съдържа английски букви.");
                    continue;
                }
                // Проверка дали рецептата вече съществува в базата данни
                if (formView.RecipeExists(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Тази рецепта вече съществува. Моля, въведете друго име.");
                    continue;
                }
                break;
            }

            string description;
            // Цикъл за въвеждане на описание на рецептата
            while (true)
            {
                Console.Write("Описание: ");
                description = Console.ReadLine();
                // Проверка дали описанието е празно или съдържа само празни символи
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Описанието не може да бъде празно.");
                    continue;
                }
                // Проверка дали описанието е по-кратко от 2 символа
                if (description.Length < 2)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 2 букви.");
                    continue;
                }
                // Проверка дали описанието съдържа само български букви
                if (!IsBulgarianText(description))
                {
                    Console.WriteLine("Описанието съдържа английски букви. Използвайте български.");
                    continue;
                }
                break;
            }

            int prepTime;
            // Цикъл за въвеждане на време за приготвяне на рецептата
            while (true)
            {
                Console.Write("Време за приготвяне (в минути): ");
                // Прочитане на времето за приготвяне и проверка дали е валидно
                if (!int.TryParse(Console.ReadLine(), out prepTime) || prepTime <= 0)
                {
                    Console.WriteLine("Невалидно време за приготвяне.");
                    continue;
                }
                break;
            }

            string difficulty;
            // Цикъл за въвеждане на трудност на рецептата
            while (true)
            {
                Console.Write("Трудност (Лесно/Средно/Трудно): ");
                difficulty = Console.ReadLine();
                // Проверка дали трудността е празна или съдържа само празни символи
                if (string.IsNullOrWhiteSpace(difficulty))
                {
                    Console.WriteLine("Моля, въведете трудност.");
                    continue;
                }
                
                var diffLower = difficulty.ToLower();
                // Проверка дали трудността е валидна
                if (diffLower != "лесно" && diffLower != "средно" && diffLower != "трудно")
                {
                    Console.WriteLine("Невалидна стойност за трудност. Допустими: Лесно, Средно, Трудно.");
                    continue;
                }
                break;
            }

            string category;
            // Цикъл за въвеждане на категория на рецептата
            while (true)
            {
                Console.Write("Категория (Предястие/Основно/Десерт): ");
                category = Console.ReadLine();
                // Проверка дали категорията е празна или съдържа само празни символи
                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Моля, въведете категория.");
                    continue;
                }

                var catLower = category.ToLower();
                // Проверка дали категорията е валидна
                if (catLower != "предястие" && catLower != "основно" && catLower != "десерт")
                {
                    Console.WriteLine("Невалидна категория. Допустими: Предястие, Основно, Десерт.");
                    continue;
                }
                break;
            }

            string instructions;
            // Цикъл за въвеждане на инструкции за рецептата
            while (true)
            {
                Console.Write("Инструкции: ");
                instructions = Console.ReadLine();
                // Проверка дали инструкциите са празни или съдържат само празни символи
                if (string.IsNullOrWhiteSpace(instructions))
                {
                    Console.WriteLine("Моля въведете инструкции.");
                    continue;
                }
                // Проверка дали инструкциите са по-кратки от 3 символа
                if (instructions.Length < 3)
                {
                    Console.WriteLine("Името на рецептата трябва да съдържа поне 3 букви.");
                    continue;
                }
                // Проверка дали инструкциите съдържат само български букви
                if (!IsBulgarianText(instructions))
                {
                    Console.WriteLine("Инструкциите съдържат английски букви. Използвайте български.");
                    continue;
                }
                break;
            }
            // Списъци за съставките и количествата
            List<string> ingredients = new List<string>();
            List<string> quantities = new List<string>();

            int count;
            // Цикъл за въвеждане на брой съставки
            while (true)
            {
                Console.Write("Брой съставки: ");
                // Прочитане на броя съставки и проверка дали е валиден
                if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    Console.WriteLine("Невалиден брой съставки.");
                    continue;
                }
                break;
            }
            // Вземане на наличните съставки от RecipeServices
            List<string> availableIngredients = formView.GetIngredientNames();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nНалични продукти в базата данни:");
            Console.WriteLine("──────────────────────────────────────");
            // Изписване на наличните съставки
            foreach (var ingr in availableIngredients)
            {
                Console.WriteLine($"{ingr}");
            }
            Console.WriteLine("──────────────────────────────────────\n");
            // Цикъл за въвеждане на съставки и количества
            for (int i = 0; i < count; i++)
            {
                string ingredient;
                // Цикъл за въвеждане на съставка
                while (true)
                {
                    Console.Write($"Продукт {i + 1}: ");
                    ingredient = Console.ReadLine();
                    // Проверка дали съставката е празна или съдържа само празни символи
                    if (string.IsNullOrWhiteSpace(ingredient))
                    {
                        Console.WriteLine($"Съставка {i + 1} не може да бъде празна.");
                        continue;
                    }
                    // Проверка дали съставката е по-кратка от 2 символа
                    if (!availableIngredients.Contains(ingredient, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Продуктът \"{ingredient}\" не съществува в базата данни.");
                        continue;
                    }
                    break;
                }
                ingredients.Add(ingredient);

                string quantity;
                // Цикъл за въвеждане на количество за съставката
                while (true)
                {
                    Console.Write("Количество: ");
                    quantity = Console.ReadLine();
                    // Проверка дали количеството е празно или съдържа само празни символи
                    if (string.IsNullOrWhiteSpace(quantity))
                    {
                        Console.WriteLine("Количеството не може да бъде празно.");
                        continue;
                    }
                    break;
                }
                quantities.Add(quantity);
            }
            // Опит за добавяне на рецептата чрез RecipeServices
            try
            {
                formView.AddRecipe(name, description, prepTime, difficulty, instructions, category, ingredients, quantities);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Рецептата е добавена успешно!");
            }
            // Хващане на изключение при грешка при добавяне на рецептата
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
        // Метод за преглед на рецепти
        private static void ViewRecipes(RecipeServices formView)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ---Magic In Plate--- \nПреглед на Рецепти\n");

            // Вземане на списъци с данни за рецепти от RecipeServices
            var recipeIds = formView.GetRecipeId();
            var recipeNames = formView.GetRecipeNames();
            var recipeDescriptions = formView.GetRecipeDescription();
            var prepTimes = formView.GetRecipePrepTime();
            var difficulties = formView.GetRecipeDifficulty();
            var categories = formView.GetRecipeCategoryName();
            var instructions = formView.GetRecipeInstructions();
            // Проверка дали има налични рецепти за преглед
            if (recipeNames.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Няма налични рецепти.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Изберете рецепта:\n");
            // Изписване на списък с рецепти за преглед
            for (int i = 0; i < recipeNames.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {recipeNames[i]}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nВашият избор: ");
            // Прочитане на избора на потребителя и проверка дали е валиден
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > recipeNames.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Невалиден избор.");
                Console.ResetColor();
                return;
            }

            int index = choice - 1;
            // Изчистване на конзолата и изписване на информация за избраната рецепта
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{choice}] {recipeNames[index]}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Описание: {recipeDescriptions[index]}");
            Console.WriteLine($"Време за приготвяне: {prepTimes[index]} минути");
            Console.WriteLine($"Трудност: {difficulties[index]}");
            Console.WriteLine($"Категория: {categories[index]}");
            Console.WriteLine($"Инструкции: {instructions[index]}\n");
            // Извличане на съставките и количествата за избраната рецепта
            var ingredients = formView.GetIngredientsForRecipe(recipeIds[index]);
            var quantities = formView.GetIngredientQuantityForRecipe(recipeIds[index]);

            Console.WriteLine("Съставки:");
            // Изписване на съставките и количествата
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

        // Метод за проверка дали текстът съдържа само български букви
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
        // Метод за изписване на съобщение за сбогуване и връщане към главното меню
        private static void SayGoodbyeAndReturn()
        {
            Console.Clear();

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
