using DomainLayer.Models;
using RepositoryLayer;
using RepositoryLayer.IRepository;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class IngredientService : IIngredient
    {

        private IIngredientRepo<Ingredient> IngredientRepository;
        public IngredientService(IIngredientRepo<Ingredient> IngredientRepository)
        {
            this.IngredientRepository = IngredientRepository;

        }

        //Get All Ingredient
        public List<Ingredient> GetAllRepo()
        {

            return IngredientRepository.GetAllRepo();

        }
        //Get Single Ingredient
        public Ingredient GetSingleRepo(int id)
        {

            return IngredientRepository.GetSingleRepo(id);

        }
        //Add Ingredient in Ingredient Table
        public String AddIngredientRepo(Ingredient ingredient)
        {
            return IngredientRepository.AddIngredientRepo(ingredient);
        }
        //Remove Ingredient
        public string RemoveIngredient(int id)
        {
            return IngredientRepository.RemoveIngredient(id);
        }
        //Update Ingredient
        public String UpdateIngredientRepo(int id, Ingredient ingredient)
        {
            return IngredientRepository.UpdateIngredientRepo(id,ingredient);
        }

    }
}
