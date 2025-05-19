using Microsoft.EntityFrameworkCore;
using PumiikaVChiniika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MagicInPlateCA;

namespace PumiikaVChiniika
{
    public class FormView
    {

        private readonly MagicInPlateContext context;

        public FormView()
        {
            context = new MagicInPlateContext();
        }
        public List<int> GetRecipeId()
        {
            return context.Recipes
                .Select(r => r.RecipeId)
                .ToList();
        }
        public List<string> GetRecipeNames()
        {
            return context.Recipes
                .Select(r => r.Name)
                .ToList();
        }
        public List<string> GetRecipeNameByIndex(int recipeId)
        {
            return context.Recipes
                .Where(ri => ri.RecipeId == recipeId)
                .Select(r => r.Name)
                .ToList();
        }
        public List<string> GetRecipeInstructions()
        {
            return context.Recipes
                .Select(r => r.Instructions)
                .ToList();
        }
        public List<string> GetIngredientsForRecipe(int recipeId)
        {
            return context.RecipeIngredients
                          .Where(ri => ri.RecipeId == recipeId)
                          .Select(ri => ri.Ingredient.Name)
                          .ToList();
        }

        public List<string> GetIngredientQuantityForRecipe(int recipeId)
        {
            return context.RecipeIngredients
                          .Where(ri => ri.RecipeId == recipeId)
                          .Select(ri => ri.Quantity)
                          .ToList();
        }
        public List<string> GetRecipeDescription()
        {
            return context.Recipes
                .Select(r => r.Description)
                .ToList();
        }
        public List<int> GetRecipePrepTime()
        {
            return context.Recipes
                .Select(r => r.PreparationTime)
                .ToList();
        }
        public List<string> GetRecipeDifficulty()
        {
            return context.Recipes
                .Select(r => r.Difficulty)
                .ToList();
        }
        public List<string> GetRecipeCategoryName()
        {
            return context.Recipes
                .Select(r => r.Category.Name)
                .ToList();
        }

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

        public List<string> GetAllIngredients()
        {
            return context.Ingredients
                          .Select(i => i.Name)
                          .ToList();
        }
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
        public void UpdateRecipe(int recipeId, string name, string description, int prepTime, string difficulty, string instructions, string categoryName, List<string> ingredientNames, List<string> quantities)
        {
            var recipe = context.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
            if (recipe == null) throw new Exception("Recipe not found.");

            var category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null) throw new Exception("Category not found.");

            
            recipe.Name = name;
            recipe.Description = description;
            recipe.PreparationTime = prepTime;
            recipe.Difficulty = difficulty;
            recipe.Instructions = instructions;
            recipe.CategoryId = category.CategoryId;

            
            var existingIngredients = context.RecipeIngredients.Where(ri => ri.RecipeId == recipeId).ToList();
            context.RecipeIngredients.RemoveRange(existingIngredients);

            
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

        public List<string> GetIngredientNames()
        {
            return context.Ingredients
                .Select(i => i.Name)
                .ToList();
        }
    }
}