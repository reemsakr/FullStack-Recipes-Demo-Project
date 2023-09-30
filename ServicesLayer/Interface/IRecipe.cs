using DomainLayer.Models;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IRecipe
    {
        //GetAll Record
        List<Recipe> GetAll();
        //Get single 
        Recipe GetSingle(int id);
        //Add Record
        String Add(Recipe recipe);
        //Update or Edit Record
        String Update(int id, Recipe recipe);
        //Delete or Remove
        String Remove(int id);

        RecipeWithIngredientsVM GetRecipeWithIngredients(int id);

        RecipeWithFeedBacksVM GetRecipeWithFeedBacks(int id);

        String GetRecipeByListOfIngredient(List<String> Ingredients);

        Recipe SearchByName(String name);

        List<Recipe> GetRecipesByCategory(string category); 
    }
}
