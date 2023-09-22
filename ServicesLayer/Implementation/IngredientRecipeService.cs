using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
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
    public class IngredientRecipeService:IIngredientRecipe
    {

        private IIngredientRecipeRepo<IngredientRecipe> IngredientRecipeRepository;
        public IngredientRecipeService(IIngredientRecipeRepo<IngredientRecipe> IngredientRecipeRepository)
        {
            this.IngredientRecipeRepository = IngredientRecipeRepository;

        }

        //Get All IngredientRecipe
        public List<IngredientRecipe> GetAllRepo()
        {

            return IngredientRecipeRepository.GetAllRepo();

        }
        //Get Single IngredientRecipe
        public IngredientRecipe GetSingleRepo(int id)
        {

            return IngredientRecipeRepository.GetSingleRepo(id);

        }
        //Add IngredientRecipe in IngredientRecipe Table
        public String AddIngredientRecipeRepo(IngredientRecipe ingredientRecipe)
        {
            return IngredientRecipeRepository.AddIngredientRecipeRepo(ingredientRecipe);


        }
        //Remove ingredientRecipe
        public string RemoveIngredientRecipe(int id)
        {
            return IngredientRecipeRepository.RemoveIngredientRecipe(id);
        }
        //Update IngredientRecipe
        public String UpdateIngredientRecipeRepo(int id, IngredientRecipe ingredientRecipe)
        {
            return IngredientRecipeRepository.UpdateIngredientRecipeRepo(id, ingredientRecipe);
        }
    }
}
