using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly AppDbContext context;
        private readonly IMemoryCache _cache;
        private DbSet<Ingredient> entities;
        string errorMessage = string.Empty;
        private readonly string cachekey = "IngredientCacheKey";
        private IRepo<Ingredient> IngredientRepository;
        public IngredientService(IRepo<Ingredient> IngredientRepository, IMemoryCache cache, AppDbContext context)
        {
            this.IngredientRepository = IngredientRepository;
            this._cache = cache;
            this.context = context;
            entities = context.Ingredients;
        }

        //Get All Ingredient
        public List<Ingredient> GetAll()
        {

            return IngredientRepository.GetAll();

        }
        //Get Single Ingredient
        public Ingredient GetSingle(int id)
        {

            return IngredientRepository.GetAll(f => f.Id == id).FirstOrDefault();

        }
        //Add Ingredient in Ingredient Table
        public String Add(Ingredient ingredient)
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
                    return IngredientRepository.Add(ingredient);
                }

                return "This Ingredient is already here";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Remove Ingredient
        public string Remove(int id)
        {
            try
            {

                var data = GetSingle(id);
                if (data != null)
                {
                    _cache.Remove(id);
                    entities.Remove(data);
                    return IngredientRepository.Remove(id);
                }

                return "Not Found Ingredient.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Update Ingredient
        public String Update(int id, Ingredient ingredient)
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
                    return IngredientRepository.Update(id, ingredient);
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
