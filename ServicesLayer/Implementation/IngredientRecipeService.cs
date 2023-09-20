using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
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
        
        private readonly AppDbContext _dbContext;

        public IngredientRecipeService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //Get All IngredientRecipe
        public List<IngredientRecipe> GetAllRepo()
        {

            return _dbContext.IngredientsRecipes.ToList();

        }
        //Get Single IngredientRecipe
        public IngredientRecipe GetSingleRepo(int id)
        {

            return _dbContext.IngredientsRecipes.Find(id);

        }
        //Add IngredientRecipe in IngredientRecipe Table
        public String AddIngredientRecipeRepo(IngredientRecipe ingredientRecipe)
        {
            
            var IR = new IngredientRecipe()
            {

                IngredientsId = ingredientRecipe.IngredientsId,
                RecipesId = ingredientRecipe.RecipesId
            };
            try
            {
                var found =  _dbContext.IngredientsRecipes.Find(IR.Id);
                var RId =  _dbContext.Recipes.Find(IR.RecipesId);
                var IId =  _dbContext.Ingredients.Find(IR.IngredientsId);
                if (found == null)
                {
                    if (RId != null && IId != null)
                    {
                        try
                        {
                             _dbContext.IngredientsRecipes.Add(IR);
                             _dbContext.SaveChanges();

                            return "Suceess Add";
                        }
                        catch
                        {
                            return ("this ingriedient is already in this recipe.");
                        }

                    }
                    else
                    {
                        return ("Please enter the correct IDs");
                    }

                }
                else
                return ("This IngredientRecipe is already here");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        //Remove ingredientRecipe
        public string RemoveIngredientRecipe(int id)
        {
            try
            {
                var data = GetSingleRepo(id);
                if (data != null)
                {
                    _dbContext.IngredientsRecipes.Remove(data);
                    _dbContext.SaveChanges();
                    return ("Delete success");
                }

                return "Not Found IngredientRecipes.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Update IngredientRecipe
        public String UpdateIngredientRecipeRepo(int id, IngredientRecipe ingredientRecipe)
        {
            try
            {
                var IngredientRecipe = new IngredientRecipe()
                {

                    IngredientsId = ingredientRecipe.IngredientsId,
                    RecipesId = ingredientRecipe.RecipesId
                };
                var found =  _dbContext.IngredientsRecipes.Find(id);

                if (found != null)
                {

                    var RId =  _dbContext.Recipes.Find(ingredientRecipe.RecipesId);
                    var IId =  _dbContext.Ingredients.Find(ingredientRecipe.IngredientsId);
                    if (RId != null && IId != null)
                    {

                        IngredientRecipe.RecipesId = ingredientRecipe.RecipesId;
                        IngredientRecipe.IngredientsId = ingredientRecipe.IngredientsId;
                         _dbContext.SaveChangesAsync();
                        return ("Success Update");
                    }
                    else
                    {
                        return ("Please enter the correct IDs");

                    }
                }
                return ("Not Found IngredientRecipe.");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
