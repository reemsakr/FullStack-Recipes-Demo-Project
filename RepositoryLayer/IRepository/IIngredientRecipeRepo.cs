
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IIngredientRecipeRepo<T>where T:IngredientRecipe 
    {
        //GetAll Record
        List<T> GetAllRepo();
        //GetSingle Record
        T GetSingleRepo(int id);
        //Add Record
        String AddIngredientRecipeRepo(T IngredientRecipe);
        //Update or Edit Record
        String UpdateIngredientRecipeRepo(int id, T IngredientRecipe);
        //Delete or Remove
        String RemoveIngredientRecipe(int id);

    }
}