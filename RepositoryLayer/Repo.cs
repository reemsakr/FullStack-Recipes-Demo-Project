using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repo<T> : IRepo<T> where T : BaseEntity
    {

        private readonly AppDbContext context;
        private DbSet<T> entities;
        private readonly IMemoryCache _cache;
        private readonly string cachekey = "RecipeCacheKey";

        public Repo(AppDbContext context, IMemoryCache cache)
        {
            this.context = context;
            this._cache = cache;
            entities = context.Set<T>();
        }

        string IRepo<T>.Add(T data)
        {

            try
            {
                if(data==null)
                {
                    throw new NotImplementedException("entity");
                }
                entities.Add(data);
                context.SaveChanges();
                return  ("Success Add"); 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        List<T> IRepo<T>.GetAll(Expression<Func<T, bool>> filter)
        {

            var data = filter == null ? entities.ToList() : entities.Where(filter).ToList();
            return data;
        }

        string IRepo<T>.Remove(int id)
        {
            try
            {
                
                context.SaveChanges();
                return ("Delete success");
            }
             catch(Exception ex)
            {
                return ex.Message;
            }
        }

        string IRepo<T>.Update(int id, T data)
        {

            try
            {
                if (data == null)
                {
                    throw new NotImplementedException("entity");
                }
                context.SaveChanges();
                return ("Success Update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
