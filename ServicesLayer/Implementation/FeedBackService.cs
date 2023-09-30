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
    public class FeedBackService : IFeedBack
    {
        private readonly AppDbContext context;
        private readonly IMemoryCache _cache;
        private DbSet<FeedBack> entities;
        string errorMessage = string.Empty;
        private readonly string cachekey = "FeedBackCacheKey";
        private IRepo<FeedBack> FeedBackRepository;
        public FeedBackService(IRepo<FeedBack> FeedBackRepository, IMemoryCache cache, AppDbContext context)
        {
            this.FeedBackRepository = FeedBackRepository;
            this._cache = cache;
            this.context = context;
            entities = context.FeedBacks;
        }

        //Get All FeedBacks
        public List<FeedBack> GetAll()
        {
            
            return FeedBackRepository.GetAll();

        }
        //Get Single FeedBack
        public FeedBack GetSingle(int id)
        {

            return FeedBackRepository.GetAll(f => f.Id == id).FirstOrDefault();

        }
        
        public String Add(FeedBack feedBack)
        {
            try
            {
                var FeedBack = new FeedBack()
                {
                    Rate =feedBack.Rate,
                    Review =feedBack.Review,
                    RecipeId =feedBack.RecipeId 

                };

                
                    return FeedBackRepository.Add(FeedBack);
                

               
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
                    return FeedBackRepository.Remove(id);
                }

                return "Not Found FeedBacks.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //Update Ingredient
        public String Update(int id, FeedBack feedBack)
        {
            try
            {
                var data = entities.Find(id);

                if (data != null)
                {
                    
                    data.Rate = feedBack.Rate;
                    data.Review = feedBack.Review;
                    data.RecipeId = feedBack.RecipeId;
                    return FeedBackRepository.Update(id, feedBack);
                }
                return ("Not Found FeedBacks.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
