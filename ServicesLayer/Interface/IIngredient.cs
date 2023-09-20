using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IIngredient
    {

        //GetAll Record
        List<Ingredient> GetAllRepo();
        //GetSingle Record
        Ingredient GetSingleRepo(int id);
        //Add Record
        String AddIngredientRepo(Ingredient recipe);
        //Update or Edit Record
        String UpdateIngredientRepo(int id, Ingredient recipe);
        //Delete or Remove
        String RemoveIngredient(int id);
    }
}
