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
        /*public List<string> GetRecipeNames(List<Recipe> recipes)
        {
            return recipes.Select(r => r.Name).ToList();
        }*/
        private readonly MagicInPlateContext context;

        public FormView()
        {
            context = new MagicInPlateContext();
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

    }
}
