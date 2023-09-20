using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
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
       
        private readonly AppDbContext _dbContext;

        public RecipeService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //Get All Recipe
        public List<Recipe> GetAllRepo()
        {
            
                return this._dbContext.Recipes.ToList();

        }
        //Get Single Recipe
        public Recipe GetSingleRepo(int id)
        {

            return this._dbContext.Recipes.SingleOrDefault(s => s.Id == id); ;

        }
        //Add Recipe in Recipe Table
        public String AddRecipeRepo(Recipe recipe)
        {
            try
            {
                var Recipe = new Recipe()
                {

                    Name = recipe.Name,
                };

                var test = _dbContext.Recipes.FirstOrDefault(r => r.Name == Recipe.Name);
                if (test == null)
                {

                    //Console.WriteLine(Recipe.Ingredients);
                    _dbContext.Recipes.Add(Recipe);
                    _dbContext.SaveChanges();

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

                var data = GetSingleRepo (id);
                if (data != null)
                {
                    _dbContext.Recipes.Remove(data);
                    _dbContext.SaveChanges();
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
        public String UpdateRecipeRepo(int id, Recipe recipe)
        {
            try
            {

                Recipe data = _dbContext.Recipes.Find(id);

                if (data != null)
                {
                    var test = _dbContext.Recipes.FirstOrDefault(r => r.Name == recipe.Name&&r.Id!=id);
                    if (test != null)
                    {
                        return ("You have to enter a unique name for your recipe");
                    }
                    data.Name = recipe.Name;
                    _dbContext.SaveChanges();
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
            var Recipe = _dbContext.Recipes.Where(n => n.Id == id).Select(n => new RecipeWithIngredientsVM()
            {
                Name = n.Name,
                IngredientName = n.IngredientRecipes.Select(n => n.Ingredient.Name).ToList()
            }).FirstOrDefault();
            return Recipe;
        }

        public String GetRecipeByListOfIngredient(List<String> Ingredients)
        {
            foreach (var Recipe in _dbContext.Recipes.ToList())
            {

                var testList = _dbContext.Recipes.Where(n => n.Id == Recipe.Id).Select(n => new RecipeWithIngredientsVM()
                {
                    Name = n.Name,
                    IngredientName = n.IngredientRecipes.Select(n => n.Ingredient.Name).ToList()
                }).FirstOrDefault();
                if (testList.IngredientName.Count() != Ingredients.Count())
                {
                    return ("Please enter the correct Ingredients.");
                }
                testList.IngredientName.Sort();
                Ingredients.Sort();
                bool flag = true;
                for (int i = 0; i < testList.IngredientName.Count(); i++)
                {
                    if (testList.IngredientName[i] != Ingredients[i])
                    {
                        flag = false;
                        break;

                    }
                }
                if (flag == true)
                {
                    return (Recipe.Name);
                }

            }

            return ("No matching recipes found.");
        }

        public Recipe SearchByName(String name)
        {
            var Recipe = new Recipe()
            {

                Name = name,

            };

            var test = _dbContext.Recipes.FirstOrDefault(r => r.Name == Recipe.Name);
            

            return test;
        }
    }
    
}
