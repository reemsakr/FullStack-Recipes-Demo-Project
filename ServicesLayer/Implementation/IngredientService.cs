using DomainLayer.Models;
using RepositoryLayer;
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
       
        private readonly AppDbContext _dbContext;

        public IngredientService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //Get All Ingredient
        public List<Ingredient> GetAllRepo()
        {

            return _dbContext.Ingredients.ToList();

        }
        //Get Single Ingredient
        public Ingredient GetSingleRepo(int id)
        {

            return this._dbContext.Ingredients.SingleOrDefault(s => s.Id == id);

        }
        //Add Ingredient in Ingredient Table
        public String AddIngredientRepo(Ingredient ingredient)
        {
            try
            {
                var Ingredient = new Ingredient()
                {

                    Name = ingredient.Name,
                };

                var test = _dbContext.Ingredients.FirstOrDefault(r => r.Name == Ingredient.Name);
                if (test == null)
                {
                    _dbContext.Ingredients.Add(Ingredient);
                    _dbContext.SaveChanges();

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
                    _dbContext.Ingredients.Remove(data);
                    _dbContext.SaveChanges();
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
        public String UpdateIngredientRepo(int id, Ingredient ingredient)
        {
            try
            {
                var data = _dbContext.Ingredients.Find(id);

                if (data != null)
                {
                    var test = _dbContext.Ingredients.FirstOrDefault(r => r.Name == ingredient.Name&& r .Id !=id);
                    if (test != null)
                    {
                        return ("You have to enter a unique name for your ingredient");
                    }
                    data.Name = ingredient.Name;
                    _dbContext.SaveChanges();
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
