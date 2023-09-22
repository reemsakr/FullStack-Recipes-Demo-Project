
using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.EntityFrameworkCore;
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
        string errorMessage = string.Empty;

        public RecipeRepo(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        //Get All Recipe
        public List<T> GetAllRepo()
        {

            return entities.ToList();
            
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
            var Recipe = entities.Where(n => n.Id == id).Select(n => new RecipeWithIngredientsVM()
            {
                Name = n.Name,
                IngredientName = n.IngredientRecipes.Select(n => n.Ingredient.Name).ToList()
            }).FirstOrDefault();
            return Recipe;
        }

        public String GetRecipeByListOfIngredient(List<String> Ingredients)
        {
            foreach (var Recipe in entities.ToList())
            {

                var testList = entities.Where(n => n.Id == Recipe.Id).Select(n => new RecipeWithIngredientsVM()
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

        public T SearchByName(String name)
        {
            var Recipe = new Recipe()
            {

                Name = name,

            };

            var test = entities.FirstOrDefault(r => r.Name == Recipe.Name);


            return test;
        }

    }
}