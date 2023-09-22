using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.IRepository;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class RecipeService : IRecipe
    {

        
       private IRecipeRepo<Recipe> RecipeRepository;
       public RecipeService(IRecipeRepo<Recipe> RecipeRepository)
       {
           this.RecipeRepository = RecipeRepository;

       }
      
        //Get All Recipe
        public List<Recipe> GetAllRepo()
        {
            return RecipeRepository.GetAllRepo();
              

        }
        //Get Single Recipe
        public Recipe GetSingleRepo(int id)
        {

            return RecipeRepository.GetSingleRepo(id);

        }
        //Add Recipe in Recipe Table
        public String AddRecipeRepo(Recipe recipe)
        {
            return RecipeRepository.AddRecipeRepo(recipe);
        }
        //Remove Recipe
        public string RemoveRecipe(int id)
        {
            return RecipeRepository.RemoveRecipe(id);
        }
        //Update Recipe
        public String UpdateRecipeRepo(int id, Recipe recipe)
        {
            return RecipeRepository.UpdateRecipeRepo(id, recipe);
        }

        public RecipeWithIngredientsVM GetRecipeWithIngredients(int id)
        {
            return RecipeRepository.GetRecipeWithIngredients(id);
        }

        public String GetRecipeByListOfIngredient(List<String> Ingredients)
        {
            return RecipeRepository.GetRecipeByListOfIngredient(Ingredients);
        }

        public Recipe SearchByName(String name)
        {
            return RecipeRepository.SearchByName(name);
        }
    }
    
}
