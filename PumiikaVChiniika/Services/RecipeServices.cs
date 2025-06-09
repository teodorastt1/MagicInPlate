using Microsoft.EntityFrameworkCore;
using PumiikaVChiniika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumiikaVChiniika.Services
{
    /// <summary>
    /// Сервизен клас, който предоставя методи за работа с рецепти и съставки в базата данни.
    /// Използва се Entity Framework Core и контекста MagicInPlateContext.
    /// </summary>
    public class RecipeServices
    {
        // Контекст за достъп до базата данни
        private readonly MagicInPlateContext context;

        /// <summary>
        /// Конструктор на класа. Инициализира нов обект от типа MagicInPlateContext.
        /// </summary>
        public RecipeServices()
        {
            context = new MagicInPlateContext();
        }

        /// <summary>
        /// Връща списък с всички RecipeId от базата данни.
        /// </summary>
        public List<int> GetRecipeId()
        {
            return context.Recipes
                .Select(r => r.RecipeId)
                .ToList();
        }

        /// <summary>
        /// Връща списък с имената на всички рецепти.
        /// </summary>
        public List<string> GetRecipeNames()
        {
            return context.Recipes
                .Select(r => r.Name)
                .ToList();
        }

        /// <summary>
        /// Връща името на рецепта по зададен ID.
        /// </summary>
        public List<string> GetRecipeNameByIndex(int recipeId)
        {
            return context.Recipes
                .Where(ri => ri.RecipeId == recipeId)
                .Select(r => r.Name)
                .ToList();
        }

        /// <summary>
        /// Връща списък с инструкциите за всички рецепти.
        /// </summary>
        public List<string> GetRecipeInstructions()
        {
            return context.Recipes
                .Select(r => r.Instructions)
                .ToList();
        }

        /// <summary>
        /// Връща списък с имената на съставките за дадена рецепта.
        /// </summary>
        public List<string> GetIngredientsForRecipe(int recipeId)
        {
            return context.RecipeIngredients
                          .Where(ri => ri.RecipeId == recipeId)
                          .Select(ri => ri.Ingredient.Name)
                          .ToList();
        }

        /// <summary>
        /// Връща списък с количествата на съставките за дадена рецепта.
        /// </summary>
        public List<string> GetIngredientQuantityForRecipe(int recipeId)
        {
            return context.RecipeIngredients
                          .Where(ri => ri.RecipeId == recipeId)
                          .Select(ri => ri.Quantity)
                          .ToList();
        }

        /// <summary>
        /// Връща описанията на всички рецепти.
        /// </summary>
        public List<string> GetRecipeDescription()
        {
            return context.Recipes
                .Select(r => r.Description)
                .ToList();
        }

        /// <summary>
        /// Връща списък с времето за приготвяне на всички рецепти.
        /// </summary>
        public List<int> GetRecipePrepTime()
        {
            return context.Recipes
                .Select(r => r.PreparationTime)
                .ToList();
        }

        /// <summary>
        /// Връща списък с нивото на трудност на всички рецепти.
        /// </summary>
        public List<string> GetRecipeDifficulty()
        {
            return context.Recipes
                .Select(r => r.Difficulty)
                .ToList();
        }

        /// <summary>
        /// Връща имената на категориите на всички рецепти.
        /// </summary>
        public List<string> GetRecipeCategoryName()
        {
            return context.Recipes
                .Select(r => r.Category.Name)
                .ToList();
        }

        /// <summary>
        /// Изтрива рецепта по зададен ID, заедно със свързаните й съставки.
        /// </summary>
        public void DeleteRecipeById(int recipeId)
        {
            var recipeToDelete = context.Recipes
                                        .FirstOrDefault(r => r.RecipeId == recipeId);

            if (recipeToDelete != null)
            {
                var relatedIngredients = context.RecipeIngredients
                                                .Where(ri => ri.RecipeId == recipeId)
                                                .ToList();

                context.RecipeIngredients.RemoveRange(relatedIngredients);
                context.Recipes.Remove(recipeToDelete);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Връща списък с имената на всички съставки.
        /// </summary>
        public List<string> GetAllIngredients()
        {
            return context.Ingredients
                          .Select(i => i.Name)
                          .ToList();
        }

        /// <summary>
        /// Добавя нова съставка, ако не съществува вече.
        /// </summary>
        public void AddIngredient(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) &&
                !context.Ingredients.Any(i => i.Name == name))
            {
                Ingredient newIngredient = new Ingredient { Name = name };
                context.Ingredients.Add(newIngredient);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Добавя нова рецепта с всички нейни данни и свързаните съставки.
        /// </summary>
        public void AddRecipe(string name, string description, int prepTime, string difficulty, string instructions, string categoryName, List<string> ingredientNames, List<string> quantities)
        {
            var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            var newRecipe = new Recipe
            {
                Name = name,
                Description = description,
                PreparationTime = prepTime,
                Difficulty = difficulty,
                Instructions = instructions,
                CategoryId = category.CategoryId
            };

            for (int i = 0; i < ingredientNames.Count; i++)
            {
                string ingredientName = ingredientNames[i];
                string quantity = quantities[i];

                var ingredient = context.Ingredients.FirstOrDefault(ing => ing.Name == ingredientName);
                if (ingredient == null)
                {
                    throw new Exception($"Ingredient '{ingredientName}' not found.");
                }

                newRecipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = quantity
                });
            }

            context.Recipes.Add(newRecipe);
            context.SaveChanges();
        }

        /// <summary>
        /// Актуализира рецепта и нейните съставки по зададен ID.
        /// </summary>
        public void UpdateRecipe(int recipeId, string name, string description, int prepTime, string difficulty, string instructions, string categoryName, List<string> ingredientNames, List<string> quantities)
        {
            var recipe = context.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
            if (recipe == null) throw new Exception("Recipe not found.");

            var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null) throw new Exception("Category not found.");

            // Актуализиране на основните данни
            recipe.Name = name;
            recipe.Description = description;
            recipe.PreparationTime = prepTime;
            recipe.Difficulty = difficulty;
            recipe.Instructions = instructions;
            recipe.CategoryId = category.CategoryId;

            // Изтриване на старите съставки
            var existingIngredients = context.RecipeIngredients.Where(ri => ri.RecipeId == recipeId).ToList();
            context.RecipeIngredients.RemoveRange(existingIngredients);

            // Добавяне на новите съставки
            for (int i = 0; i < ingredientNames.Count; i++)
            {
                string ingredientName = ingredientNames[i];
                string quantity = quantities[i];

                var ingredient = context.Ingredients.FirstOrDefault(ing => ing.Name == ingredientName);
                if (ingredient == null) throw new Exception($"Ingredient '{ingredientName}' not found.");

                context.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.RecipeId,
                    IngredientId = ingredient.IngredientId,
                    Quantity = quantity
                });
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Връща списък с имената на всички съставки (дублира се с GetAllIngredients).
        /// </summary>
        public List<string> GetIngredientNames()
        {
            return context.Ingredients
                .Select(i => i.Name)
                .ToList();
        }

        /// <summary>
        /// Проверява дали съществува рецепта с дадено име (без значение от големината на буквите и интервалите).
        /// </summary>
        public bool RecipeExists(string name)
        {
            return context.Recipes
                          .Any(r => r.Name.Trim().ToLower() == name.Trim().ToLower());
        }
    }
}
