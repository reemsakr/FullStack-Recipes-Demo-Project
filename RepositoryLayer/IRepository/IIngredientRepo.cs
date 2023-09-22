
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IIngredientRepo<T> where T : Ingredient
    {

        //GetAll Record
        List<T> GetAllRepo();
        //GetSingle Record
        T GetSingleRepo(int id);
        //Add Record
        String AddIngredientRepo(T recipe);
        //Update or Edit Record
        String UpdateIngredientRepo(int id, T recipe);
        //Delete or Remove
        String RemoveIngredient(int id);
    }
}