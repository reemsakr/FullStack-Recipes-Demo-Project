using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IIngredientRecipe
    {
        //GetAll Record
        List<IngredientRecipe> GetAllRepo();
        //GetSingle Record
        IngredientRecipe GetSingleRepo(int id);
        //Add Record
        String AddIngredientRecipeRepo(IngredientRecipe IngredientRecipe);
        //Update or Edit Record
        String UpdateIngredientRecipeRepo(int id, IngredientRecipe IngredientRecipe);
        //Delete or Remove
        String RemoveIngredientRecipe(int id);
    }
}
