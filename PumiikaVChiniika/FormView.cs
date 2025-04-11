using PumiikaVChiniika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
