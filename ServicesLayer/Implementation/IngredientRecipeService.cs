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
        private readonly AppDbContext context;
        private DbSet<IngredientRecipe> entities;

        private IRepo<IngredientRecipe> IngredientRecipeRepository;
        public IngredientRecipeService(IRepo<IngredientRecipe> IngredientRecipeRepository, AppDbContext context)
        {
            this.IngredientRecipeRepository = IngredientRecipeRepository;
            this.context = context;
            entities = context.IngredientsRecipes;
        }

        //Get All IngredientRecipe
        public List<IngredientRecipe> GetAll()
        {

            return IngredientRecipeRepository.GetAll();

        }
        //Get Single IngredientRecipe
        public IngredientRecipe GetSingle(int id)
        {

            return IngredientRecipeRepository.GetAll(f => f.Id == id).FirstOrDefault();

        }
        //Add IngredientRecipe in IngredientRecipe Table
        public String Add(IngredientRecipe ingredientRecipe)
        {
            var IR = new IngredientRecipe()
            {

                IngredientsId = ingredientRecipe.IngredientsId,
                RecipesId = ingredientRecipe.RecipesId
            };
            try
            {
                var found = entities.Find(IR.Id);
                var RId = context.Recipes.Find(IR.RecipesId);
                var IId = context.Ingredients.Find(IR.IngredientsId);

                if (found == null)
                {
                    if (RId != null && IId != null)
                    {
                        try
                        {
                            return IngredientRecipeRepository.Add(ingredientRecipe);
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
        public string Remove(int id)
        {
            try
            {
                var data = GetSingle(id);
                if (data != null)
                {
                    entities.Remove(data);
                    return IngredientRecipeRepository.Remove(id);
                }

                return "Not Found IngredientRecipes.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        //Update IngredientRecipe
        public String Update(int id, IngredientRecipe ingredientRecipe)
        {
            try
            {
                var IngredientRecipe = new IngredientRecipe()
                {

                    IngredientsId = ingredientRecipe.IngredientsId,
                    RecipesId = ingredientRecipe.RecipesId
                };
                var found = entities.Find(id);

                if (found != null)
                {

                    var RId = entities.Find(ingredientRecipe.RecipesId);
                    var IId = entities.Find(ingredientRecipe.IngredientsId);
                    if (RId != null && IId != null)
                    {

                        IngredientRecipe.RecipesId = ingredientRecipe.RecipesId;
                        IngredientRecipe.IngredientsId = ingredientRecipe.IngredientsId;
                        return IngredientRecipeRepository.Update(id, ingredientRecipe);
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
