
using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RepositoryLayer.Repository
{
    public class RecipeRepo<T> : IRecipeRepo <T> where T : Recipe
    {
        private readonly AppDbContext context;
        private  DbSet<T> entities;
        private readonly IMemoryCache _cache;
        private readonly string cachekey = "RecipeCacheKey";
        public RecipeRepo(AppDbContext context,IMemoryCache cache)
        {
            this.context = context;
            this._cache = cache;
            entities = context.Set<T>();
        }
        //Get All Recipe
        public List<T> GetAllRepo()
        {
            if (_cache.TryGetValue(cachekey, out List<T> data))
                return data;
            data = entities.ToList();
            var cacheOptions = new MemoryCacheEntryOptions()
           .SetSize(1) // maximum cache size in number of entries
           .SetSlidingExpiration(TimeSpan.FromMinutes(5)) // cache expiration time after last access
           .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)); // cache expiration time after creation

            _cache.Set(cachekey, data, cacheOptions);
            return data;
        }
        //Get Single Recipe
        public T GetSingleRepo(int id)
        {

            return entities.SingleOrDefault(s => s.Id == id); ;

        }
        //Add Recipe in Recipe Table
        public String AddRecipeRepo(T recipe)
        {
            try
            {
                var Recipe = new Recipe()
                {

                    Name = recipe.Name,
                };

                var test = entities.FirstOrDefault(r => r.Name == Recipe.Name);
                if (test == null)
                {

                    
                    entities.Add((T)Recipe);
                    context.SaveChanges();

                    return ("Success Add");
                }

                return "This recipe is already here";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Remove Recipe
        public string RemoveRecipe(int id)
        {
            try
            {

                var data = GetSingleRepo(id);
                if (data != null)
                {
                    _cache.Remove(id);
                    entities.Remove(data);
                    context.SaveChanges();
                    return ("Delete success");
                }

                return "Not Found Recipes.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Update Recipe
        public String UpdateRecipeRepo(int id, T recipe)
        {
            try
            {

                T data = entities.Find(id);

                if (data != null)
                {
                    var test = entities.FirstOrDefault(r => r.Name == recipe.Name && r.Id != id);
                    if (test != null)
                    {
                        return ("You have to enter a unique name for your recipe");
                    }
                    data.Name = recipe.Name;
                    context.SaveChanges();
                    return ("Success Update");
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
           return _cache.GetOrCreate($"Ingredients:{Ingredients}", cacheEntry => {
            var data = "";
                foreach (var Recipe in entities.ToList())
                {
                    var testList = entities.Where(n => n.Id == Recipe.Id).Select(n => new RecipeWithIngredientsVM()
                    {
                        Name = n.Name,
                        IngredientName = n.IngredientRecipes.Select(n => n.Ingredient.Name).ToList()
                    }).FirstOrDefault();
                
                    if (testList.IngredientName.Count() != Ingredients.Count())
                    {
                   
                        data = "Please enter the correct Ingredients.";
                    }
                    else
                    {
                    testList.IngredientName.Sort();
                    Ingredients.Sort();
                    
                    bool flag = true;
                    for (int i = 0; i < testList.IngredientName.Count(); i++)
                    {
                        Console.WriteLine(testList.IngredientName[0]);
                        if (testList.IngredientName[i] != Ingredients[i])
                        {
                            flag = false;
                            break;

                        }
                    }

                    if (flag == true)
                    {
                        
                        return data= Recipe.Name;
                    }
                }
                    

                   
                }
                return data;
            });
        }
           
        
        public T SearchByName(String name)
        {
            return _cache.GetOrCreate($"name:{name}", cacheEntry =>
            {
                //if (_cache.TryGetValue(cachekey, out T data)) return data;
                var Recipe = new Recipe()
                {

                    Name = name,

                };

                var data = entities.FirstOrDefault(r => r.Name == Recipe.Name);
                var cacheOptions = new MemoryCacheEntryOptions()
               .SetSize(1) // maximum cache size in number of entries
               .SetSlidingExpiration(TimeSpan.FromMinutes(5)) // cache expiration time after last access
               .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)); // cache expiration time after creation

                _cache.Set(cachekey, data, cacheOptions);
                return data;

            });
        }

    }
}