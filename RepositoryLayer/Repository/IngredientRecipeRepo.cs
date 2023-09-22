
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class IngredientRecipeRepo<T> : IIngredientRecipeRepo <T> where T:IngredientRecipe
    {
        private readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public IngredientRecipeRepo(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        //Get All IngredientRecipe
        public List<T> GetAllRepo()
        {

            return entities.ToList();

        }
        //Get Single IngredientRecipe
        public T GetSingleRepo(int id)
        {

            return entities.Find(id);

        }
        //Add IngredientRecipe in IngredientRecipe Table
        public String AddIngredientRecipeRepo(T ingredientRecipe)
        {

            var IR = new IngredientRecipe()
            {

                IngredientsId = ingredientRecipe.IngredientsId,
                RecipesId = ingredientRecipe.RecipesId
            };
            try
            {
                var found = entities.Find(IR.Id);
                var RId = entities.Find(IR.RecipesId);
                var IId = entities.Find(IR.IngredientsId);
                if (found == null)
                {
                    if (RId != null && IId != null)
                    {
                        try
                        {
                           entities.Add((T)IR);
                            context.SaveChanges();

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
                    entities.Remove(data);
                    context.SaveChanges();
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
        public String UpdateIngredientRecipeRepo(int id, T ingredientRecipe)
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
                        context.SaveChangesAsync();
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
