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
        List<Recipe> GetAllRepo();
        //GetSingle Record
        Recipe GetSingleRepo(int id);
        //Add Record
        String AddRecipeRepo(Recipe recipe);
        //Update or Edit Record
        String UpdateRecipeRepo(int id, Recipe recipe);
        //Delete or Remove
        String RemoveRecipe(int id);

        RecipeWithIngredientsVM GetRecipeWithIngredients(int id);

        String GetRecipeByListOfIngredient(List<String> Ingredients);

        Recipe SearchByName(String name);
    }
}
