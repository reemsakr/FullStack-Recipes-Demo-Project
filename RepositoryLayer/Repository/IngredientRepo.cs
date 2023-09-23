
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RepositoryLayer.IRepository;

namespace RepositoryLayer.Repository
{
    public class IngredientRepo<T> : IIngredientRepo<T> where T : Ingredient
    {
        private readonly AppDbContext context;
        private readonly IMemoryCache _cache;
        private  DbSet<T> entities;
        string errorMessage = string.Empty;
        private readonly string cachekey = "IngredientCacheKey";
        public IngredientRepo(AppDbContext context, IMemoryCache cache)
        {
            this._cache = cache;
            this.context = context;
            entities = context.Set<T>();
        }

        //Get All Ingredient
        public  List<T> GetAllRepo()
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
        //Get Single Ingredient
        public T GetSingleRepo(int id)
        {

            return entities.SingleOrDefault(s => s.Id == id);

        }
        //Add Ingredient in Ingredient Table
        public String AddIngredientRepo(T ingredient)
        {
            try
            {
                var Ingredient = new Ingredient()
                {

                    Name = ingredient.Name,
                };

                var test = entities.FirstOrDefault(r => r.Name == Ingredient.Name);
                if (test == null)
                {
                    entities.Add((T)Ingredient);
                    context.SaveChanges();

                    return ("Success Add");
                }

                return "This Ingredient is already here";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Remove Ingredient
        public string RemoveIngredient(int id)
        {
            try
            {
                var data = GetSingleRepo(id);
                if (data != null)
                {
                    entities.Remove(data);
                    context.SaveChanges();
                    return ("Delete success");
                }

                return "Not Found Ingredient.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Update Ingredient
        public String UpdateIngredientRepo(int id, T ingredient)
        {
            try
            {
                var data = entities.Find(id);

                if (data != null)
                {
                    var test = entities.FirstOrDefault(r => r.Name == ingredient.Name && r.Id != id);
                    if (test != null)
                    {
                        return ("You have to enter a unique name for your ingredient");
                    }
                    data.Name = ingredient.Name;
                    context.SaveChanges();
                    return ("Success Update");
                }
                return ("Not Found Ingredient.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
