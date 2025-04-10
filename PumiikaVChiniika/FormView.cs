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

    }
}
