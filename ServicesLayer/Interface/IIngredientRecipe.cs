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
        List<IngredientRecipe> GetAll();
        //Get single 
        IngredientRecipe GetSingle(int id);
        //Add Record
        String Add(IngredientRecipe IngredientRecipe);
        //Update or Edit Record
        String Update(int id, IngredientRecipe IngredientRecipe);
        //Delete or Remove
        String Remove(int id);
    }
}
