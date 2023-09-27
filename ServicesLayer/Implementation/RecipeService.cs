using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly AppDbContext context;
        private DbSet<Recipe> entities;
        private readonly IMemoryCache _cache;
        private readonly string cachekey = "RecipeCacheKey";

        private IRepo<Recipe> RecipeRepository;
       public RecipeService(IRepo<Recipe> RecipeRepository, IMemoryCache cache, AppDbContext context)
       {
           this.RecipeRepository = RecipeRepository;
            this._cache = cache;
            this.context = context;
            entities = context.Recipes;
        }
      
        //Get All Recipe
        public List<Recipe> GetAll()
        {
            return RecipeRepository.GetAll();
              

        }
        //Get Single Recipe
        
        public Recipe GetSingle(int id)
        {

            return RecipeRepository.GetAll(f => f.Id== id).FirstOrDefault();

        }
        
        //Add Recipe in Recipe Table
        public String Add(Recipe recipe)
        {
            try
            {
                var Recipe = new Recipe()
                {

                    Name = recipe.Name,
                };

                var test = RecipeRepository.GetAll(f => f.Name.Contains(Recipe.Name)).FirstOrDefault();
                if (test == null)
                {
                   return  RecipeRepository.Add(Recipe);
                }

                return "This recipe is already here";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Remove Recipe
        public string Remove(int id)
        {
            try
            {

                var data = GetSingle(id);
                if (data != null)
                {
                    _cache.Remove(id);
                    entities.Remove(data);
                    return RecipeRepository.Remove(id);
                }

                return "Not Found Recipes.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            
        }
        //Update Recipe
        public String Update(int id, Recipe recipe)
        {

            try
            {

                var data = entities.Find(id);

                if (data != null)
                {
                    var test = entities.FirstOrDefault(r => r.Name == recipe.Name && r.Id != id);
                    if (test != null)
                    {
                        return ("You have to enter a unique name for your recipe");
                    }
                    data.Name = recipe.Name;
                    return RecipeRepository.Update(id, data);
                }
                return ("Not Found Recipe.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        
        public RecipeWithIngredientsVM GetRecipeWithIngredients(int id)
        {
            return _cache.GetOrCreate($"id:{id}", cacheEntry =>
            {
                var Recipe = entities.Where(n => n.Id == id).Select(n => new RecipeWithIngredientsVM()
                {
                    Name = n.Name,
                    IngredientName = n.IngredientRecipes.Select(n => n.Ingredient.Name).ToList()
                }).FirstOrDefault();
                var cacheOptions = new MemoryCacheEntryOptions()
               .SetSize(1) // maximum cache size in number of entries
               .SetSlidingExpiration(TimeSpan.FromMinutes(5)) // cache expiration time after last access
               .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)); // cache expiration time after creation

                _cache.Set(cachekey, Recipe, cacheOptions);

                return Recipe;

            });
        }
        
        public String GetRecipeByListOfIngredient(List<String> Ingredients)
        {
            return RecipeRepository
                .GetAll(f => f.IngredientRecipes.Any(s=>Ingredients.Contains(s.Ingredient.Name)))
                .FirstOrDefault().Name;

            
        }

        public Recipe SearchByName(String name)
        {
         return   RecipeRepository.GetAll(f => f.Name.Contains(name)).FirstOrDefault();
            
        }
    }
    
}
