
using DomainLayer.Models;
using DomainLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IRecipeRepo<T> where T : Recipe
    {
        //GetAll Record
        List<T> GetAllRepo();
        //GetSingle Record
        T GetSingleRepo(int id);
        //Add Record
        String AddRecipeRepo(T recipe);
        //Update or Edit Record
        String UpdateRecipeRepo(int id, T recipe);
        //Delete or Remove
        String RemoveRecipe(int id);

        RecipeWithIngredientsVM GetRecipeWithIngredients(int id);

        String GetRecipeByListOfIngredient(List<String> Ingredients);

        T SearchByName(String name);

    }
}