
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;

namespace RepositoryLayer.Repository
{
    public class IngredientRepo<T> : IIngredientRepo<T> where T : Ingredient
    {
        private readonly AppDbContext context;
        private  DbSet<T> entities;
        string errorMessage = string.Empty;

        public IngredientRepo(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        //Get All Ingredient
        public List<T> GetAllRepo()
        {

            return entities.ToList();

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
